namespace SplitProject.Domain.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public string? ExpenseTitle { get; set; } = "Unknown Expense";
        public decimal ExpenseAmount { get; set; }
        public int UserId { get; set; } //Внешний ключ для Юзеров (ByUser)
        public User User { get; set; } //Кто совершил трату
        public List<Benefiter> Benefiters { get; set; } //На кого делят

        public Expense()
        { }

        //public Expense(string expenseTitle, double expenseAmount, int byUserId)
        //{
        //    Benefiters = new List<Benefiter>();
        //    ExpenseTitle = expenseTitle;
        //    ExpenseAmount = expenseAmount;
        //    UserId = byUserId;
        //}
    }
}