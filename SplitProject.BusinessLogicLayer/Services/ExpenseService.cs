using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

namespace SplitProject.BLL.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IDbCrudService _dbCrud;
        public ExpenseService(IDbCrudService dbCrud)
        {
            _dbCrud = dbCrud;
        }

        public void CountExpense(decimal amount, Guid userIdFrom, List<Benefiter> benefitersList) //Counting expense, updates DB
        {
            User userFrom = _dbCrud.GetUserById(userIdFrom);
            userFrom.Balance += amount;
            int totalPercent = 0;
            foreach (Benefiter b in benefitersList)
            {
                User userToBenefit = _dbCrud.GetUserById(b.Id);
                userToBenefit.Balance -= amount * b.Percent / 100;
                totalPercent += b.Percent;
            }
            if (totalPercent == 100)
            {
                _dbCrud.SaveChanges();

            }
            else
            {
                throw new ArgumentException("wrong percent Sum");
            }
        }
    }
}
