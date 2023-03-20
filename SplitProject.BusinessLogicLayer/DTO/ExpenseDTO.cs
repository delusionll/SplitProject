namespace SplitProject.Domain.Models
{
    public class ExpenseDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public string? ExpenseTitle { get; set; }
        public decimal ExpenseAmount { get; set; }
        public Guid UserId { get; set; }
        public List<BenefiterDTO> BenefitersDTO { get; set; }
    }
}