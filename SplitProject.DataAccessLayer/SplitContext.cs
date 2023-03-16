using Microsoft.EntityFrameworkCore;
using SplitProject.Models;

namespace SplitProject.DataBase
{
    public class SplitContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Benefiter> Benefiters { get; set; }

        public SplitContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SplitContext;Integrated Security=True")
                    .LogTo(Console.WriteLine); //Пока захардкодил. Не получается получить свойство GetConnectionString из appsettings
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benefiter>()
                .HasOne(b => b.User)
                .WithMany(u => u.Benefiters)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}