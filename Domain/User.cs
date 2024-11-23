namespace Domain;

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
    public User(string name = null) => Name = name;

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="balance">User balance.</param>
    /// <param name="name">   User name.</param>
    /// <param name="userID"> User ID.</param>
    public User(Guid userID, decimal balance, string name = null)
    {
        Balance = balance;
        Name = name;
        UserID = userID;
    }

    /// <summary>
    /// Gets or sets user balance.
    /// </summary>
    public decimal Balance { get; set; } = 0;

    /// <summary>
    /// Gets userbenefiters. navigation prop.
    /// </summary>
    public ICollection<UserBenefiter> Benefiters { get; private set; } = [];

    /// <summary>
    /// Gets a list of user expenses.
    /// </summary>
    public ICollection<Expense> Expenses { get; private set; } = [];

    /// <summary>
    /// Gets or sets username.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets user ID.
    /// </summary>
    public Guid UserID { get; private set; } = Guid.NewGuid();
}