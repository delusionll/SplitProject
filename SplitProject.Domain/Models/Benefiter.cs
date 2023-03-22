namespace SplitProject.Domain.Models
{
    public class Benefiter
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Percent { get; set; }
        public Guid UserId { get; set; }
        public Guid ExpenseId { get; set; }
        //
        public Expense Expense { get; set; }
        public User User { get; set; }

        //public Benefiter(int percent, Guid userToBenefitId)
        //{
        //    BenefiterPercent = percent;
        //    UserId = userToBenefitId;
        //}

        //public Benefiter()
        //{ }
    }
}