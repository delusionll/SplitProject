namespace Domain.Models;

using System;
using System.Collections.Generic;

/// <summary>
/// Expense entity.
/// </summary>
public class Expense
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Expense"/> class.
    /// </summary>
    /// <remarks>Empty ctor for EF.</remarks>
    public Expense()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Expense"/> class.
    /// </summary>
    /// <param name="title">Title.</param>
    /// <param name="amount">Amount.</param>
    /// <param name="byUser">User who did the expense.</param>
    /// <param name="benefiters">A list of users to benefit in this expense.</param>
    public Expense(string? title, decimal amount, Guid byUser, List<UserBenefiter>? benefiters = null)
    {
        Title = title;
        Amount = amount;
        UserID = byUser;
        Benefiters = benefiters;
    }

    /// <summary>
    /// Gets expense ID.
    /// </summary>
    public Guid ExpenseID { get; private set; } = Guid.NewGuid();

    /// <summary>
    /// Gets total amount of expense.
    /// </summary>
    public decimal Amount { get; private set; }

    /// <summary>
    /// Gets date.
    /// </summary>
    public DateTime Date { get; private set; } = DateTime.Now;

    /// <summary>
    /// Gets title.
    /// </summary>
    public string? Title { get; private set; }

    /// <summary>
    /// Gets a list of users to benefit in expense.
    /// </summary>
    public List<UserBenefiter>? Benefiters { get; private set; } = [];

    /// <summary>
    /// Gets User ID who did the expense.
    /// </summary>
    // Foreign key for Users (byUser)
    public Guid UserID { get; private set; }
}