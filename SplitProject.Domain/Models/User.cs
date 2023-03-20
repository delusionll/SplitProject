namespace SplitProject.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? UserName { get; set; }
        public decimal UserBalance { get; set; }

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