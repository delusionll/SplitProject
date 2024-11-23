namespace API;

using System;
using System.IO;
using BLL.IServices;
using BLL.Services;
using DAL;
using Domain;
using DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

/// <summary>
/// StartPoint.
/// </summary>
internal sealed class Program
{
    private static void Main()
    {
        var builder = WebApplication.CreateBuilder();
        string connectionString = builder.Configuration.GetConnectionString("Default");
        string migrationsAssembly = builder.Configuration["MigrationsAssembly"];
        var services = builder.Services;

        // TODO ???
        builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

        services.AddTransient<IExpenseService, ExpenseService>();
        services.AddTransient<IDTOService<Expense, ExpenseDTO>, ExpenseDTOService>();
        services.AddTransient<IDTOService<User, UserDTO>, UserDTOService>();
        services.AddTransient<IDTOService<UserBenefiter, UserBenefiterDTO>, UserBenefiterDTOService>();
        services.AddScoped<IRepository, SplitRepository>();
        services.AddDbContext<SplitContext>(
        options => options.UseSqlServer(
            connectionString,
            sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);

                // TODO remove hardcode
                sqlOptions.MigrationsAssembly(migrationsAssembly);
            })
            .AddInterceptors(new ContextInterceptor()));
        services.AddControllers();
        services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo() { Title = "Split", Version = "v1", });
            x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "SplitApi.xml"));
        });
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

        // TODO add app.UseExceptionHandler(...
        _ = app.MapGet(
            "/GetExpense",
            async (
                IExpenseService expenseService,
                Guid id,
                IDTOService<Expense, ExpenseDTO> dtoService) =>
        {
            if (id == Guid.Empty)
                return Results.BadRequest("Wrong ID");

            var expenseDTO = await expenseService
                .GetByIdAsync(id).ConfigureAwait(false);
            return expenseDTO == null ?
                Results.NotFound($"Expense id {id} not found") :
                Results.Ok(expenseDTO);
        });

        _ = app.MapPost(
            "/NewExpense",
            async (
                ExpenseDTO newExpense,
                IDTOService<Expense, ExpenseDTO> dtoService,
                IExpenseService expenseService) =>
        {
            if (newExpense == null)
                return Results.BadRequest("Expense data is required.");

            try
            {
                await expenseService.CreateAsync(newExpense).ConfigureAwait(false);
                return Results.Ok();
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

        _ = app.MapDelete("/DeleteAllUsers", async (IUserService service) =>
        {
            await service.DeleteAllAsync().ConfigureAwait(false);
            return Results.Ok();
        });

        _ = app.MapDelete("/DeleteUserById", async (
                IUserService service, Guid id) =>
        {
            try
            {
                await service.DeleteByIdAsync(id).ConfigureAwait(false);
            }
            catch
            {
                return Results.BadRequest();
            }

            return Results.Ok();
        });

        _ = app.MapGet("/GetUserById", async (
            IUserService userService, Guid id) =>
        {
            var userDTO = await userService.GetByIdAsync(id).ConfigureAwait(false);

            if (userDTO == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(userDTO);
        });

        _ = app.MapPost("/NewUser", async (
            IUserService userService, [FromBody] string name) =>
        {
            var result = await userService.AddAsync(name).ConfigureAwait(false);
            return result == null ? Results.BadRequest() : Results.Ok(result);
        });

        app.Run();
    }
}