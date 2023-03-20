namespace SplitProject.Domain.Models
{
    public class Benefiter
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int BenefiterPercent { get; set; }
        public Guid UserId { get; set; } //Внешний ключ к Юзерам
        public Guid ExpenseId { get; set; } //Внешний ключ к таблице Expense
        //
        public Expense Expense { get; set; }
        public User User { get; set; }

        public Benefiter(int percent, Guid userToBenefitId)
        {
            BenefiterPercent = percent;
            UserId = userToBenefitId;
        }

        //public Benefiter()
        //{ }
    }
}