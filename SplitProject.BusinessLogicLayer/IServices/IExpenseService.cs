using SplitProject.Domain.Models;

namespace SplitProject.BLL.IServices
	{
	public interface IExpenseService
		{
		void CountExpense(decimal amount, Guid userIdFrom, List<Benefiter> benefitersList);
		}
	}
