using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

namespace SplitProject.BLL.Services;

public class ExpenseDtoService : IDtoService<Expense, ExpenseDTO>
{
	public Expense ToEntity(ExpenseDTO expenseDto)
	{
		List<Benefiter> benefiters = new();
		foreach (var b in expenseDto.Benefiters) benefiters.Add(BenefiterDtoToEntity(b));
		Expense entity = new()
		{
			Title = expenseDto.Title,
			Amount = expenseDto.Amount,
			UserId = expenseDto.UserId,
			Benefiters = benefiters
		};
		return entity;
	}

	public ExpenseDTO ToDto(Expense expense)
	{
		List<BenefiterDTO> benefitersDTO = new();
		foreach (var b in expense.Benefiters) benefitersDTO.Add(BenefiterToDto(b));
		return new ExpenseDTO
		{
			Title = expense.Title,
			Amount = expense.Amount,
			UserId = expense.UserId,
			Benefiters = benefitersDTO
		};
	}

	public static Benefiter BenefiterDtoToEntity(BenefiterDTO benefiterDto)
	{
		Benefiter benefiter = new()
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
}