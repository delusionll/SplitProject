namespace SplitProject.BLL.DTO;

public class ExpenseDTO
{
    public string? ExpenseTitle { get; set; }
    public decimal ExpenseAmount { get; set; }
    public Guid UserId { get; set; }
    public List<BenefiterDTO> Benefiters { get; set; } = new List<BenefiterDTO>();
}