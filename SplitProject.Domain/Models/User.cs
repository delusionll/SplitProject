namespace SplitProject.Domain.Models;

using System.Collections.ObjectModel;

public class User
{
    public decimal Balance { get; }

    public Collection<Benefiter> Benefiters { get; } = [];

    public Collection<Expense> Expenses { get; } = [];

    public Guid Id { get; } = Guid.NewGuid();

    public string? Name { get; }
}