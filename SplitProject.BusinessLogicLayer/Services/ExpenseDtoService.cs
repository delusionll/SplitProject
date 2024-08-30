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
    private readonly UserDtoService _userDtoService = new UserDtoService();

    /// <inheritdoc/>
    public ExpenseDTO ToDto(Expense entity)
    {
        IList<KeyValuePair<UserDTO, int>> benefitersDTO = [];
        foreach (var b in entity.Benefiters)
        {
            benefitersDTO.Add(new KeyValuePair<UserDTO, int>(_userDtoService.ToDto(b.Key), b.Value));
        }

        return new ExpenseDTO(entity.Amount, benefitersDTO, entity.Title, entity.UserId);
    }

    /// <inheritdoc/>
    public Expense ToEntity(ExpenseDTO dto)
    {
        Collection<KeyValuePair<User, int>> benefiters = [];
        foreach (var b in dto.Benefiters)
        {
            benefiters.Add(new KeyValuePair<User, int>(_userDtoService.ToEntity(b.Key), b.Value));
        }

        return new Expense(dto.Title, dto.Amount, dto.UserId, benefiters);
    }
}