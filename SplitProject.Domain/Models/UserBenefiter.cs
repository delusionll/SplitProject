namespace SplitProject.Domain.Models;

/// <summary>
/// Benefiter entity.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserBenefiter"/> class.
/// </remarks>
public class UserBenefiter
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserBenefiter"/> class.
    /// </summary>
    /// <param name="user">User as Benefiter.</param>
    /// <param name="amount">amount.</param>
    /// <param name="share">share.</param>
    /// <param name="expense">expense entity.</param>
    public UserBenefiter(User user, decimal amount, int share, Expense expense)
    {
        User = user;
        Amount = amount;
        Share = share;
        Expense = expense;
    }

    /// <summary>
    /// Gets or sets user.
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Gets or sets amount to benefit.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets benefiter share.
    /// </summary>
    public int Share { get; set; }

    /// <summary>
    /// Gets or sets expense. Foreign key for Expense.
    /// </summary>
    public Expense Expense { get; set; }
}