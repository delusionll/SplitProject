namespace SplitProject.Bll.DTO;

using System;

/// <summary>
/// UserBenefiter DTO.
/// </summary>
public class UserBenefiterDTO
{
    /// <summary>
    /// Gets user as Benefiter ID.
    /// </summary>
    public Guid UserID { get; }

    /// <summary>
    /// Gets amount to share.
    /// </summary>
    public decimal Amount { get; }

    /// <summary>
    /// Gets share percent.
    /// </summary>
    public int Share { get; }

    /// <summary>
    /// Gets expense ID.
    /// </summary>
    public Guid ExpenseID { get; }
}