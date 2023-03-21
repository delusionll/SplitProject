using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

namespace SplitProject.BLL.Services
{
    public class ExpenseDtoService : IDtoService<Expense, ExpenseDTO>
    {
        public Expense ToEntity(ExpenseDTO expenseDto)
        {
            List<Benefiter> benefiters = new();
            foreach (BenefiterDTO b in expenseDto.Benefiters)
            {
                benefiters.Add(BenefiterDtoToEntity(b));
            }
            Expense entity = new()
            {
                ExpenseTitle = expenseDto.ExpenseTitle,
                ExpenseAmount = expenseDto.ExpenseAmount,
                UserId = expenseDto.UserId,
                Benefiters = benefiters
            };
            return entity;
        }

        public static Benefiter BenefiterDtoToEntity(BenefiterDTO benefiterDto)
        {
            Benefiter benefiter = new()
            {
                BenefiterPercent = benefiterDto.BenefiterPercent,
                UserId = benefiterDto.ExpenseId,
                ExpenseId = benefiterDto.ExpenseId
            };
            return benefiter;
        }

        public ExpenseDTO ToDto(Expense expense)
        {
            List<BenefiterDTO> benefitersDTO = new();
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

        public static BenefiterDTO BenefiterToDto(Benefiter benefiter)
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
