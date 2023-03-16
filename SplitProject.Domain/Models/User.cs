namespace SplitProject.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string? UserName { get; set; }
        public double UserBalance { get; set; }

        public List<Expense> Expenses { get; set; } //Какие траты совершил
        public List<Benefiter> Benefiters { get; set; } //В каких тратах участвует

        public User(string username)
        {
            Expenses = new List<Expense>();
            Benefiters = new List<Benefiter>();
            UserName = username;
            UserBalance = 0;
        }

        public User()
        { }
    }
}