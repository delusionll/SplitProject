namespace SplitProject.BLL.DTO;

using System;
using System.Collections.Generic;
using SplitProject.Bll.DTO;
using SplitProject.Domain.Models;

/// <summary>
/// <see cref="Expense"/> DTO.
/// </summary>
public class ExpenseDTO
{
    /// <summary>
    /// Gets expense amount.
    /// </summary>
    public decimal Amount { get; }

    /// <summary>
    /// Gets users to Benefit.
    /// </summary>
    public ICollection<UserBenefiterDTO>? Benefiters { get; }

    /// <summary>
    /// Gets expense Title.
    /// </summary>
    public string? Title { get; }

    /// <summary>
    /// Gets expense owner UserID.
    /// </summary>
    public Guid UserID { get; }
}