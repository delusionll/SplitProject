using SplitProject.Domain.Models;

namespace SplitProject.BLL
{
    public class DtoService : IDtoService
    {
        public Expense ExpenseDtoToEntity(ExpenseDTO expenseDto)
        {
            List<Benefiter> benefiters = new List<Benefiter>();
            foreach (BenefiterDTO b in expenseDto.Benefiters)
            {
                benefiters.Add(BenefiterDtoToEntity(b));
            }
            Expense entity = new Expense()
            {
                ExpenseTitle = expenseDto.ExpenseTitle,
                ExpenseAmount = expenseDto.ExpenseAmount,
                UserId = expenseDto.UserId,
                Benefiters = benefiters
            };
            return entity;
        }

        public Benefiter BenefiterDtoToEntity(BenefiterDTO benefiterDto)
        {
            Benefiter benefiter = new Benefiter()
            {
                BenefiterPercent = benefiterDto.BenefiterPercent,
                UserId = benefiterDto.ExpenseId,
                ExpenseId = benefiterDto.ExpenseId
            };
            return benefiter;
        }


    }
}
