namespace SplitProject.Domain.Models;

public class User
{
    public decimal Balance { get; set; }

    public List<Benefiter> Benefiters { get; set; } = new();

    public List<Expense> Expenses { get; set; } = new();

    public Guid Id { get; set; } = Guid.NewGuid();

    public string? Name { get; set; }
}