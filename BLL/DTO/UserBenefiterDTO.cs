namespace BLL.DTO;

using System;

/// <summary>
/// UserBenefiter DTO.
/// </summary>
public class UserBenefiterDTO(Guid userID, decimal amount, int share, Guid expenseID)
{
    /// <summary>
    /// Gets user as Benefiter ID.
    /// </summary>
    public Guid UserID { get; } = userID;

    /// <summary>
    /// Gets amount to share.
    /// </summary>
    public decimal Amount { get; } = amount;

    /// <summary>
    /// Gets share percent.
    /// </summary>
    public int Share { get; } = share;

    /// <summary>
    /// Gets expense ID.
    /// </summary>
    public Guid ExpenseID { get; } = expenseID;
}