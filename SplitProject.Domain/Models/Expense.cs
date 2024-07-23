namespace SplitProject.Domain.Models;

using System.Collections.ObjectModel;

public class Expense
{
    public decimal Amount { get; set; }

    public Collection<Benefiter> Benefiters { get; set; } = new();

    public DateTime Date { get; set; } = DateTime.Now;

    public Guid Id { get; set; } = Guid.NewGuid();

    public string? Title { get; set; }

    public User? User { get; set; }

    public Guid UserId { get; set; } //Foreign key for Users (byUser)
}