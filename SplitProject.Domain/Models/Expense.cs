namespace SplitProject.Domain.Models
{
    public class Expense
    {
        public Guid Id { get; set; }

        public DateTime ExpenseDate { get; set; }
        public string? ExpenseTitle { get; set; }
        public decimal ExpenseAmount { get; set; }
        public Guid UserId { get; set; } //Foreign key for Users (byUser)
        //
        public User User { get; set; }
        public List<Benefiter> Benefiters { get; set; }

        //public Expense()
        //{ }

        //public Expense(string expenseTitle, double expenseAmount, int byUserId)
        //{
        //    Benefiters = new List<Benefiter>();
        //    ExpenseTitle = expenseTitle;
        //    ExpenseAmount = expenseAmount;
        //    UserId = byUserId;
        //}
    }
}