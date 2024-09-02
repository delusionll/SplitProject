namespace SplitProject.BLL.DTO;

using System;
using System.Collections.Generic;
using SplitProject.Domain.Models;

/// <summary>
/// <see cref="Expense"/> DTO.
/// </summary>
public class ExpenseDTO(decimal amount, ICollection<UserBenefiterDTO>? benefiters, string? title, Guid userID)
{
    /// <summary>
    /// Gets expense amount.
    /// </summary>
    public decimal Amount { get; } = amount;

    /// <summary>
    /// Gets users to Benefit.
    /// </summary>
    public ICollection<UserBenefiterDTO>? Benefiters { get; } = benefiters;

    /// <summary>
    /// Gets expense Title.
    /// </summary>
    public string? Title { get; } = title;

    /// <summary>
    /// Gets expense owner UserID.
    /// </summary>
    public Guid UserID { get; } = userID;
}