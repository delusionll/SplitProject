﻿namespace SplitProject.DAL;

using Domain.Models;
using Microsoft.EntityFrameworkCore;

public class SplitContext : DbContext
{
    public SplitContext(DbContextOptions<SplitContext> options) : base(options)
    {
    }


    public DbSet<User>      Users      { get; set; }
    public DbSet<Expense>   Expenses   { get; set; }
    public DbSet<Benefiter> Benefiters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Benefiter>()
            .HasOne(b => b.User)
            .WithMany(u => u.Benefiters)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>().Property(u => u.Balance).HasPrecision(13, 2);
        modelBuilder.Entity<Expense>().Property(e => e.Amount).HasPrecision(13, 2); //12345678901.23
    }
}