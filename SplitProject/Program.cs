namespace SplitProject.API;

using BLL.DTO;
using BLL.IServices;
using BLL.Services;
using DAL;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        var services = builder.Services; //Services collection adding
        services.AddTransient<IExpenseService, ExpenseService>();
        services.AddScoped<IDbCrudService, DbCrudService>();
        services.AddTransient<IDtoService<Expense, ExpenseDTO>, ExpenseDtoService>();
        services.AddTransient<IDtoService<User, UserDTO>, UserDtoService>();
        services.AddDbContext<SplitContext>
        (options => options.UseSqlServer(builder.Configuration["ConnectionString:Default"],
            builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)));
        services.AddControllers(); ////Controllers support adding
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

        app.Run();
    }
}