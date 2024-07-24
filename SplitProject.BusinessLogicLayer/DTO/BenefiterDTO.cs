namespace SplitProject.BLL.DTO;

public class BenefiterDTO
{
    public BenefiterDTO(Guid expenseId, int percent, Guid userId)
    {
        ExpenseId = expenseId;
        Percent = percent;
        UserId = userId;
    }

    public Guid ExpenseId { get; }

    public int Percent { get; }

    public Guid UserId { get; }
}