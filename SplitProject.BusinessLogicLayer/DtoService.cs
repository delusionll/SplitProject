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

        public ExpenseDTO ExpenseToDto(Expense expense)
        {
            List<BenefiterDTO> benefitersDTO = new List<BenefiterDTO>();
            foreach (Benefiter b in expense.Benefiters)
            {
                benefitersDTO.Add(BenefiterToDto(b));
            }
            return new ExpenseDTO()
            {
                ExpenseTitle = expense.ExpenseTitle,
                ExpenseAmount = expense.ExpenseAmount,
                UserId = expense.UserId,
                Benefiters = benefitersDTO
            };
        }

        public BenefiterDTO BenefiterToDto(Benefiter benefiter)
        {
            return new BenefiterDTO()
            {
                BenefiterPercent = benefiter.BenefiterPercent,
                UserId = benefiter.UserId,
                ExpenseId = benefiter.ExpenseId
            };
        }
    }
}
