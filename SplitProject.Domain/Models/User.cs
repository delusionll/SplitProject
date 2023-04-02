namespace SplitProject.Domain.Models
	{
	public class User
		{
		public Guid Id { get; set; } = Guid.NewGuid();

		public string? Name { get; set; }
		public decimal Balance { get; set; }
		//
		public List<Expense> Expenses { get; set; } = new List<Expense>();
		public List<Benefiter> Benefiters { get; set; } = new List<Benefiter>();

		//public User(string username)
		//{
		//    Expenses = new List<Expense>();
		//    Benefiters = new List<Benefiter>();
		//    UserName = username;
		//    UserBalance = 0;
		//}

		//public User()
		//{ }
		}
	}