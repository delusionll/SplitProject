namespace SplitProject.BLL.DTO;

using System;
using System.Collections.Generic;

public class ExpenseDTO
{
    public ExpenseDTO(decimal amount, IEnumerable<KeyValuePair<UserDTO, int>> benefiters, string? title, Guid userId)
    {
        Amount = amount;
        Benefiters = benefiters;
        Title = title;
        UserId = userId;
    }

    public decimal Amount { get; set; }

    public IEnumerable<KeyValuePair<UserDTO, int>> Benefiters { get; } = [];

    public string? Title { get; set; }

    public Guid UserId { get; set; }
}