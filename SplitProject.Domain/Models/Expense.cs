namespace SplitProject.Domain.Models;

using System.Collections.ObjectModel;

public class Expense
{
    public decimal Amount { get; }

    public Collection<Benefiter> Benefiters { get; } = [];

    public DateTime Date { get; } = DateTime.Now;

    public Guid Id { get; } = Guid.NewGuid();

    public string? Title { get; }

    public User? User { get; }

    public Guid UserId { get; } // Foreign key for Users (byUser)
}