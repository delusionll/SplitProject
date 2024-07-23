namespace SplitProject.BLL.IServices;

using System.Collections.ObjectModel;
using Domain.Models;

public interface IExpenseService
{
    void CountExpense(decimal amount, Guid userIdFrom, Collection<Benefiter> benefitersList);
}