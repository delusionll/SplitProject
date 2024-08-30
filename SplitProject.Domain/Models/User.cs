namespace SplitProject.Domain.Models;

using System.Collections.ObjectModel;

public class User
{
    public User() {}

    public User(string? name = null)
    {
        Name = name;
    }
    public User(decimal balance, string? name = null)
    {
        Balance = balance;
        Name = name;
    }

    public decimal Balance { get; set; } = 0;

    public IEnumerable<Expense> Expenses { get; } = [];

    public Guid Id { get;private set; } = Guid.NewGuid();

    public string? Name { get; }
}