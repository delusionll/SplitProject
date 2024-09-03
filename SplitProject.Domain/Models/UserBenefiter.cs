namespace SplitProject.Domain.Models;

using System;

/// <summary>
/// Benefiter entity.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserBenefiter"/> class.
/// </remarks>
public class UserBenefiter
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserBenefiter"/> class. For EF.
    /// </summary>
    public UserBenefiter()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserBenefiter"/> class.
    /// </summary>
    /// <param name="user">User as Benefiter.</param>
    /// <param name="amount">amount.</param>
    /// <param name="share">share.</param>
    /// <param name="expenseID">expense entity.</param>
    public UserBenefiter(User user, decimal amount, int share, Guid expenseID)
    {
        User = user;
        Amount = amount;
        Share = share;
        ExpenseID = expenseID;
    }

    /// <summary>
    /// Gets entity ID.
    /// </summary>
    public Guid ID { get; private set; } = Guid.NewGuid();

    /// <summary>
    /// Gets user.
    /// </summary>
    public User User { get; private set; }

    /// <summary>
    /// Gets amount to benefit.
    /// </summary>
    public decimal Amount { get; private set; }

    /// <summary>
    /// Gets benefiter share.
    /// </summary>
    public int Share { get; private set; }

    /// <summary>
    /// Gets expense. Foreign key for Expense.
    /// </summary>
    public Guid ExpenseID { get; private set; }

    /// <summary>
    /// Gets user ID. Foreign Key for users.
    /// </summary>
    public Guid UserID { get; private set; }
}