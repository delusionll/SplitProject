namespace SplitProject.Domain.Models;

/// <summary>
/// Benefiter entity.
/// </summary>
public class UserBenefiter
{
    /// <summary>
    /// Gets or sets user.
    /// </summary>
    public required User User { get; set; }

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
    public required Expense Expense { get; set; }
}