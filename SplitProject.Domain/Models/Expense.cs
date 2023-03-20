namespace SplitProject.Domain.Models
{
    public class Expense
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public string? ExpenseTitle { get; set; }
        public decimal ExpenseAmount { get; set; }
        public Guid UserId { get; set; } //Внешний ключ для Юзеров (ByUser)
        public User User { get; set; } //Кто совершил трату
        public List<Benefiter> Benefiters { get; set; } //На кого делят

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