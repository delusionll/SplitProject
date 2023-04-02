namespace SplitProject.Domain.Models
	{
	public class Expense
		{
		public Guid Id { get; set; } = Guid.NewGuid();

		public DateTime Date { get; set; } = DateTime.Now;
		public string? Title { get; set; }
		public decimal Amount { get; set; }
		public Guid UserId { get; set; } //Foreign key for Users (byUser)
										 //
		public User? User { get; set; }
		public List<Benefiter> Benefiters { get; set; } = new List<Benefiter>();

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