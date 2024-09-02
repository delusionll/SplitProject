namespace SplitProject.Domain.Models;

using System;
using System.Collections.Generic;

/// <summary>
/// User entity.
/// </summary>
public class User
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <remarks>Empty ctor for EF.</remarks>
    public User()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="name">User name.</param>
    public User(string? name = null) => Name = name;

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="balance">User balance.</param>
    /// <param name="name">User name.</param>
    public User(decimal balance, string? name = null)
    {
        Balance = balance;
        Name = name;
    }

    /// <summary>
    /// Gets or sets user balance.
    /// </summary>
    public decimal Balance { get; set; } = 0;

    /// <summary>
    /// Gets a list of user expenses.
    /// </summary>
    public IList<Expense> Expenses { get; } = [];

    /// <summary>
    /// Gets or sets user ID.
    /// </summary>
    public Guid UserID { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets username.
    /// </summary>
    public string? Name { get; set; }
}