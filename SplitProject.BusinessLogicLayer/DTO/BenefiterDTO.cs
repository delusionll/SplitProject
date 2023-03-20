namespace SplitProject.Domain.Models
{
    public class BenefiterDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int BenefiterPercent { get; set; }
        public Guid UserId { get; set; }
        public Guid ExpenseId { get; set; }
    }
}