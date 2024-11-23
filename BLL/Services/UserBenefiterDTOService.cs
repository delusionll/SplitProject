namespace BLL.Services;

using System;
using BLL.IServices;
using DAL;
using Domain;
using DTOs;

/// <summary>
/// User DTO service.
/// </summary>
public class UserBenefiterDTOService : IDTOService<UserBenefiter, UserBenefiterDTO>
{
    private readonly IRepository _repository;

    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="UserBenefiterDTOService"/> class.
    /// </summary>
    /// <param name="repository">repo instance.</param>
    public UserBenefiterDTOService(IRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository, nameof(repository));
        _repository = repository;
    }

    /// <inheritdoc/>
    public UserBenefiterDTO Map(UserBenefiter entity) => new UserBenefiterDTO(
        entity.User.UserID,
        entity.Share,
        entity.ExpenseID);

    /// <inheritdoc/>
    public UserBenefiter Map(UserBenefiterDTO dto)
    {
        var user = _repository.GetById<User>(dto.UserID);
        var expense = _repository.GetById<Expense>(dto.ExpenseID);
        return user != null && expense != null
            ? new UserBenefiter(user, dto.Share, expense.ExpenseID)
            : throw new ArgumentException("User or Expense not found");
    }
}