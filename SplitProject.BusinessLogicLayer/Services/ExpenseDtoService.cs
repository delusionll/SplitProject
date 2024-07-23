namespace SplitProject.BLL.Services;

using System.Collections.ObjectModel;
using Domain.Models;
using DTO;
using IServices;

public class ExpenseDtoService : IDtoService<Expense, ExpenseDTO>
{
    public static Benefiter BenefiterDtoToEntity(BenefiterDTO benefiterDto)
    {
        Benefiter benefiter = new ()
        {
            Percent = benefiterDto.Percent,
            UserId = benefiterDto.ExpenseId,
            ExpenseId = benefiterDto.ExpenseId
        };
        return benefiter;
    }

    public static BenefiterDTO BenefiterToDto(Benefiter benefiter)
    {
        return new BenefiterDTO
        {
            Percent = benefiter.Percent,
            UserId = benefiter.UserId,
            ExpenseId = benefiter.ExpenseId
        };
    }

    public ExpenseDTO ToDto(Expense expense)
    {
        Collection<BenefiterDTO> benefitersDTO = new ();
        foreach (var b in expense.Benefiters)
            benefitersDTO.Add(BenefiterToDto(b));
        return new ExpenseDTO
        {
            Title = expense.Title,
            Amount = expense.Amount,
            UserId = expense.UserId,
            Benefiters = benefitersDTO
        };
    }

    public Expense ToEntity(ExpenseDTO expenseDto)
    {
        Collection<Benefiter> benefiters = new ();
        foreach (var b in expenseDto.Benefiters)
            benefiters.Add(BenefiterDtoToEntity(b));
        Expense entity = new ()
        {
            Title = expenseDto.Title,
            Amount = expenseDto.Amount,
            UserId = expenseDto.UserId,
            Benefiters = benefiters
        };
        return entity;
    }
}