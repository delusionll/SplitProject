using SplitProject.BLL.IServices;
using SplitProject.DAL;
using SplitProject.Domain.Models;

namespace SplitProject.BLL.Services
{
    public class DbCrudService : IDbCrudService
    {
        private readonly SplitContext _context;

        public DbCrudService(SplitContext context)
        {
            _context = context;
        }

        public User GetUserById(Guid id)
        {
            User entity = _context.Users.Find(id);
            return entity;
        }

        public Expense GetExpenseById(Guid Id)
        {
            Expense entity = _context.Expenses.Find(Id);
            return entity;
        }

        public void DeleteUserById(Guid id)
        {
            _context.Users.Remove(GetUserById(id));
            SaveChanges();
        }

        public void DeleteExpenseById(Guid id)
        {
            _context.Expenses.Remove(GetExpenseById(id));
            SaveChanges();
        }

        public void DeleteAllUsers()
        {
            foreach (User u in _context.Users)
            {
                _context.Users.Remove(u);
            }
            SaveChanges();
        }

        public virtual void AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            SaveChanges();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            SaveChanges();
        }

        public void DeleteAllExpenses()
        {
            foreach (Expense e in _context.Expenses)
            {
                _context.Expenses.Remove(e);
            }
            SaveChanges();
        }

        public void ClearDataBase()
        {
            DeleteAllExpenses();
            DeleteAllUsers();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
