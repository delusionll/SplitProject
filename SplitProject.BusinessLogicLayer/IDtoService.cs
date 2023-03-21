using SplitProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitProject.BLL
{
    public interface IDtoService
    {
        public Benefiter BenefiterDtoToEntity(BenefiterDTO benefiterDto);
        public Expense ExpenseDtoToEntity(ExpenseDTO expenseDto);
        public ExpenseDTO ExpenseToDto(Expense expense);
    }
}
