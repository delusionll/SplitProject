namespace SplitProject.Domain.Models;

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
    /// <param name="user">User who did the expense.</param>
    /// <param name="benefiters">A list of users to benefit in this expense.</param>
    public Expense(string? title, decimal amount, User user, IList<UserBenefiter>? benefiters = null)
    {
        Title = title;
        Amount = amount;
        User = user;
        Benefiters = benefiters;
    }

    /// <summary>
    /// Gets or sets expense ID.
    /// </summary>
    public Guid ExpenseID { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets total amount of expense.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets a list of users to benefit in expense.
    /// </summary>
    public IList<UserBenefiter>? Benefiters { get; set; } = [];

    /// <summary>
    /// Gets or sets date.
    /// </summary>
    public DateTime Date { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets title.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets <see cref="User"/>> who did the expense.
    /// </summary>
    // Foreign key for Users (byUser)
    public User User { get; set; }
}