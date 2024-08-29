namespace SplitProject.Domain.Models;

using System.Collections.ObjectModel;

public class Expense
{
    public decimal Amount { get; set;}

    public Collection<Benefiter> Benefiters { get; set;} = [];

    public DateTime Date { get; } = DateTime.Now;

    public Guid Id { get; } = Guid.NewGuid();

    public string? Title { get; set;}

    public User? User { get; }

    public Guid UserId { get; set;} // Foreign key for Users (byUser)
}