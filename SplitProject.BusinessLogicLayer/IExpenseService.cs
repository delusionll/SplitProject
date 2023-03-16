using SplitProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitProject.BLL
{
    public interface IExpenseService
    {
        public void CountExpense(decimal amount, Guid userIdFrom, List<Benefiter> benefitersList);
    }
}
