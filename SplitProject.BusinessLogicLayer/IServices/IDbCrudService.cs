using SplitProject.Domain.Models;

namespace SplitProject.BLL.IServices
{
    public interface IDbCrudService
    {
        public User GetUserById(Guid Id);
        public Expense GetExpenseById(Guid Id);
        public void DeleteUserById(Guid Id);
        public void DeleteExpenseById(Guid Id);
        public void DeleteAllUsers();
        public void DeleteAllExpenses();
        public void AddUser(User user);
        public void AddExpense(Expense expense);
        public void SaveChanges();
        public void ClearDataBase();

    }
}
