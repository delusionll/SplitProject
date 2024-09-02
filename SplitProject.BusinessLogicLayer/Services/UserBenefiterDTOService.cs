namespace SplitProject.BLL.Services;

using System;
using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

/// <summary>
/// User DTO service.
/// </summary>
/// <param name="crudService">CRUD service instance.</param>
public class UserBenefiterDTOService(ICRUDService crudService) : IDTOService<UserBenefiter, UserBenefiterDTO>
{
    private readonly ICRUDService _crudService = crudService ?? throw new ArgumentNullException(nameof(crudService));

    /// <inheritdoc/>
    public UserBenefiterDTO Map(UserBenefiter entity) => new UserBenefiterDTO(
        entity.User.UserID,
        entity.Amount,
        entity.Share,
        entity.Expense.ExpenseID);

    /// <inheritdoc/>
    public UserBenefiter Map(UserBenefiterDTO dto)
    {
        var user = _crudService.GetById<User>(dto.UserID);
        var expense = _crudService.GetById<Expense>(dto.ExpenseID);
        return user != null && expense != null
            ? new UserBenefiter(user, dto.Amount, dto.Share, expense)
            : throw new ArgumentException("User or Expense not found");
    }
}