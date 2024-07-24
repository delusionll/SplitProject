namespace SplitProject.Domain.Models;

using System.Collections.ObjectModel;

public class User
{
    public User(decimal balance, string? name = null)
    {
        Balance = balance;
        Name = name;
    }

    public decimal Balance { get; set; }

    public Collection<Benefiter> Benefiters { get; } = [];

    public Collection<Expense> Expenses { get; } = [];

    public Guid Id { get; } = Guid.NewGuid();

    public string? Name { get; }
}