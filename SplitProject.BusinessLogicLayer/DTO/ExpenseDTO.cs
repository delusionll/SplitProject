namespace SplitProject.BLL.DTO;

using System.Collections.ObjectModel;

public class ExpenseDTO
{
    public decimal Amount { get; set; }

    public Collection<BenefiterDTO> Benefiters { get; } = [];

    public string? Title { get; set; }

    public Guid UserId { get; set; }
}