using Microsoft.EntityFrameworkCore;
using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.BLL.Services;
using SplitProject.DAL;
using SplitProject.Domain.Models;

namespace SplitProject.API
{

    public class Program
    {
        private static void Main()
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder();

            IServiceCollection services = builder.Services; //Services collection adding
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddScoped<IDbCrudService, DbCrudService>();
            services.AddTransient<IDtoService<Expense, ExpenseDTO>, ExpenseDtoService>();
            services.AddTransient<IDtoService<User, UserDTO>, UserDtoService>();
            services.AddDbContext<SplitContext>
                (options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SplitContext;Integrated Security=True",
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
}