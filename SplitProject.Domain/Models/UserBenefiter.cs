namespace SplitProject.Domain;

using System;

/// <summary>
/// Benefiter entity.
/// </summary>
public class UserBenefiter
{
    /// <summary>
    /// Gets or sets user ID.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets amount to benefit.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets benefiter share.
    /// </summary>
    public int Share { get; set; }

    /// <summary>
    /// Gets or sets expense Id. Foreign key for Expense.
    /// </summary>
    public Guid ExpenseId { get; set; }
}