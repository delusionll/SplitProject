namespace SplitProject.BLL.DTO;

using System;
using System.Collections.Generic;

public class ExpenseDTO
{
    public ExpenseDTO(decimal amount, ICollection<KeyValuePair<Guid, int>> benefiters, string? title, Guid userId)
    {
        Amount = amount;
        Benefiters = benefiters;
        Title = title;
        UserId = userId;
    }

    public decimal Amount { get; set; }

/// <summary>
/// KVPair: UserId, percent
/// </summary>
    public ICollection<KeyValuePair<Guid, int>> Benefiters { get; } = [];

    public string? Title { get; set; }

    public Guid UserId { get; set; }
}