﻿namespace DAL;

using Domain;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// DB context.
/// </summary>
/// <remarks>
/// Initializes a new instance of the
/// <see cref="SplitContext"/> class.
/// </remarks>
/// <param name="options">Context options.</param>
public class SplitContext(
    DbContextOptions<SplitContext> options) : DbContext(options)
{
    /// <summary>
    /// Gets or sets benefiters.
    /// </summary>
    public DbSet<UserBenefiter> Benefiters { get; set; } = null!;

    /// <summary>
    /// Gets or sets expenses.
    /// </summary>
    public DbSet<Expense> Expenses { get; set; } = null!;

    /// <summary>
    /// Gets or sets users.
    /// </summary>
    public DbSet<User> Users { get; set; } = null!;

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserBenefiter>()
            .HasOne(b => b.User)
            .WithMany(u => u.Benefiters)
            .HasForeignKey(b => b.UserID)
            .OnDelete(DeleteBehavior.NoAction);

        // 12345678901.23
        modelBuilder.Entity<User>().Property(u => u.Balance)
            .HasPrecision(13, 2);
        modelBuilder.Entity<Expense>().Property(e => e.Amount)
            .HasPrecision(13, 2);
    }
}