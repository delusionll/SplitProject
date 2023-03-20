using SplitProject.DAL;
using SplitProject.Domain.Models;

namespace SplitProject.BLL
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

        public void DeleteUserById(Guid id)
        {
            _context.Users.Remove(GetUserById(id));
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

        public void AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
