namespace SplitProject.BLL.DTO;

public class ExpenseDTO
{
    public string?            Title      { get; set; }
    public decimal            Amount     { get; set; }
    public Guid               UserId     { get; set; }
    public List<BenefiterDTO> Benefiters { get; set; } = new ();
}