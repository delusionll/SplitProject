namespace API;

using System;
using BLL.IServices;
using BLL.Services;
using Domain;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

/// <summary>
/// StartPoint.
/// </summary>
public class Program
{
    private static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        var services = builder.Services;
        builder.Logging.AddConsole();

        // TODO transient ???
        services.AddTransient<IExpenseService, ExpenseService>();
        services.AddScoped<ICRUDService, CRUDService>();
        services.AddTransient<IDTOService<Expense, ExpenseDTO>, ExpenseDTOService>();
        services.AddTransient<IDTOService<User, UserDTO>, UserDTOService>();
        services.AddTransient<IDTOService<UserBenefiter, UserBenefiterDTO>, UserBenefiterDTOService>();
        services.AddDbContext<SplitContext>(
        options => options.UseSqlServer(
            builder.Configuration["ConnectionString:Default"],
            sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);

                // TODO remove hardcode
                sqlOptions.MigrationsAssembly("DAL");
            })
            .AddInterceptors(new ContextInterceptor()));
        services.AddControllers();
        services.AddSwaggerGen();
        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/Swagger/v1/Swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
        app.MapControllers();

        app.MapGet("/GetExpense", async (Guid id, IDTOService<Expense, ExpenseDTO> dtoService) =>
        {
            if (id == Guid.Empty)
                return Results.BadRequest("Wrong ID");

            var expense = await crudService.GetByIdAsync<Expense>(id).ConfigureAwait(false);
            if (expense.Value == null)
                return Results.NotFound($"Expense id {id} not found");

            var expenseDto = dtoService.Map(expense.Value);
            return Results.Ok(expenseDto);
        });

        app.MapPost("/NewExpense", async (ExpenseDTO newExpense, IDTOService<Expense, ExpenseDTO> dtoService, IExpenseService expenseService) =>
        {
            if (newExpense == null)
                return Results.BadRequest("Expense data is required.");

            try
            {
                var result = await expenseService.CreateAsync(newExpense).ConfigureAwait(false);
                return Results.Ok(dtoService.Map(result));
            }
            catch (ArgumentNullException ex)
            {
                return Results.BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return Results.BadRequest("Internal server failure");
            }
        });

        app.MapDelete("/DeleteAllUsers", async () =>
        {
            await crudService.DeleteAllAsync<User>().ConfigureAwait(false);
            return Results.Ok();
        });

        app.MapDelete("/DeleteUserById", async (IDTOService<User, UserDTO> dtoService, Guid id) =>
        {
            var user = await crudService.GetByIdAsync<User>(id).ConfigureAwait(false);
            if (user != null)
            {
                await crudService.DeleteByIdAsync<User>(id).ConfigureAwait(false);
                if (user.Value == null)
                    return Results.BadRequest();

                return Results.Ok(dtoService.Map(user.Value));
            }
            return Results.NotFound();
        });

        app.MapGet("/GetUserById", async (IDTOService<User, UserDTO> dtoService, Guid id) =>
        {
            var entity = await crudService.GetByIdAsync<User>(id).ConfigureAwait(false);

            if (entity.Value == null)
                return Results.NotFound();

            var userDTO = dtoService.Map(entity.Value);
            return Results.Ok(userDTO);
        });

        app.MapPost("/NewUser", async (IDTOService<User, UserDTO> dtoService, ILogger<UserController> logger, [FromBody] string name) =>
        {
            var newUser = new User(name);
            var result = await crudService.AddAsync(newUser).ConfigureAwait(false);
            logger.LogInformation(DateTime.Now.ToString(), name);
            if (result == null)
                return Results.BadRequest();

            return Results.Ok(newUser);
        });

        app.Run();
    }
}