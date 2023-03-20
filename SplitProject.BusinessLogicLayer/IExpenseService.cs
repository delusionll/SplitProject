using SplitProject.Domain.Models;

namespace SplitProject.BLL
{
    public interface IExpenseService
    {
        void CountExpense(decimal amount, Guid userIdFrom, List<BenefiterDTO> benefitersList);
        Expense DtoToEntity(ExpenseDTO expense)
        {
            Expense entity = new Expense()
            {
                Id = expense.Id,
                ExpenseDate = expense.ExpenseDate,
                ExpenseTitle = expense.ExpenseTitle,
                ExpenseAmount = expense.ExpenseAmount,
                UserId = expense.UserId,
                Benefiters = expense.BenefitersDTO

            }
        }
}
}
