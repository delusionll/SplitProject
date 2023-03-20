using SplitProject.DAL;
using SplitProject.Domain.Models;

namespace SplitProject.BLL
{
    public class ExpenseService : IExpenseService
    {
        private readonly SplitContext _context;
        private readonly DbCrudService _dbCrud;
        public ExpenseService(SplitContext context, DbCrudService dbCrud)
        {
            _context = context;
            _dbCrud = dbCrud;
        }

        public void CountExpense(decimal amount, Guid userIdFrom, List<Benefiter> benefitersList) //Counting expense, updates DB
        {
            User userFrom = _dbCrud.GetUserById(userIdFrom);
            userFrom.UserBalance += amount;
            double totalPercent = 0;
            foreach (Benefiter b in benefitersList)
            {
                User userToBenefit = _dbCrud.GetUserById(b.Id);
                userToBenefit.UserBalance -= amount * b.BenefiterPercent / 100;
                totalPercent += b.BenefiterPercent;
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
