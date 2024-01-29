namespace SplitProject.BLL.IServices;

using Domain.Models;

public interface IExpenseService
{
    void CountExpense(decimal amount, Guid userIdFrom, List<Benefiter> benefitersList);
}