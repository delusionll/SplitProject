namespace SplitProject.Domain.Models;

/// <summary>
/// Benefiter entity.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserBenefiter"/> class.
/// </remarks>
/// <param name="user">User as Benefiter.</param>
/// <param name="amount">amount.</param>
/// <param name="share">share.</param>
/// <param name="expense">expense entity.</param>
public class UserBenefiter(User user, decimal amount, int share, Expense expense)
{

    /// <summary>
    /// Gets user.
    /// </summary>
    public User User { get; private set; } = user;

    /// <summary>
    /// Gets amount to benefit.
    /// </summary>
    public decimal Amount { get; private set; } = amount;

    /// <summary>
    /// Gets benefiter share.
    /// </summary>
    public int Share { get; private set; } = share;

    /// <summary>
    /// Gets expense. Foreign key for Expense.
    /// </summary>
    public Expense Expense { get; private set; } = expense;
}