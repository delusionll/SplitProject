namespace SplitProject.BLL.DTO;

using System.Collections.ObjectModel;

public class ExpenseDTO
{
    public ExpenseDTO(decimal amount, Collection<BenefiterDTO> benefiters, string? title, Guid userId)
    {
        Amount = amount;
        Benefiters = benefiters;
        Title = title;
        UserId = userId;
    }

    public decimal Amount { get; set; }

    public Collection<BenefiterDTO> Benefiters { get; } = [];

    public string? Title { get; set; }

    public Guid UserId { get; set; }
}