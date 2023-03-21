namespace SplitProject.Domain.Models
{
    public class BenefiterDTO
    {
        public int BenefiterPercent { get; set; }
        public Guid UserId { get; set; }
        public Guid ExpenseId { get; set; }
    }
}