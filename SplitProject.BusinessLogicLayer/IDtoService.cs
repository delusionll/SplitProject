﻿using SplitProject.Domain.Models;

namespace SplitProject.BLL
{
    public interface IDtoService
    {
        public Benefiter BenefiterDtoToEntity(BenefiterDTO benefiterDto);
        public Expense ExpenseDtoToEntity(ExpenseDTO expenseDto);
        public ExpenseDTO ExpenseToDto(Expense expense);
    }
}
