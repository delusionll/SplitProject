namespace SplitProject.BLL.Services;

using System.Collections.ObjectModel;
using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

/// <summary>
/// Expense DTO.
/// </summary>
public class ExpenseDtoService : IDtoService<Expense, ExpenseDTO>
{
    private readonly BenefiterDtoService _benefiterDtoService = new();

    /// <inheritdoc/>
    public ExpenseDTO ToDto(Expense entity)
    {
        Collection<BenefiterDTO> benefitersDTO = [];
        foreach (var b in entity.Benefiters)
        {
            benefitersDTO.Add(_benefiterDtoService.ToDto(b));
        }

        return new ExpenseDTO(entity.Amount, benefitersDTO, entity.Title, entity.UserId);
    }

    /// <inheritdoc/>
    public Expense ToEntity(ExpenseDTO dto)
    {
        Collection<Benefiter> benefiters = [];
        foreach (var b in dto.Benefiters)
        {
            benefiters.Add(_benefiterDtoService.ToEntity(b));
        }

        Expense entity = new()
        {
            Title = dto.Title,
            Amount = dto.Amount,
            UserId = dto.UserId,
            Benefiters = benefiters,
        };
        return entity;
    }
}