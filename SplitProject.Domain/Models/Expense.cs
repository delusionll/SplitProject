namespace SplitProject.Domain.Models;

using System;
using System.Collections.Generic;

public class Expense
{
    public Guid Id { get;private set; } = Guid.NewGuid();

    public Expense() { }

    public Expense(string? title, decimal amount, Guid userId, IEnumerable<KeyValuePair<User, int>> benefiters)
    {
        Title = title;
        Amount = amount;
        UserId = userId;
        Benefiters = benefiters;
    }

    public decimal Amount { get; set; }

/// <summary>
/// KVpair user-percent
/// </summary>
    public IEnumerable<KeyValuePair<User, int>> Benefiters { get; } = [];

    public DateTime Date { get; } = DateTime.Now;

    public string? Title { get; set; }

    public User? User { get; }

    // Foreign key for Users (byUser)
    public Guid UserId { get; private set; }
}