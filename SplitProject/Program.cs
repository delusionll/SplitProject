namespace API;

using System;
using BLL.DTO;
using BLL.IServices;
using BLL.Services;
using DAL;
using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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
                sqlOptions.MigrationsAssembly("SplitProject.DAL");
            }));
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

        app.Run();
    }
}