namespace BLL.Services;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BLL.IServices;
using Domain;
using DTOs;

/// <summary>
/// Expense DTO.
/// </summary>
public class ExpenseDTOService(
    IDTOService<UserBenefiter, UserBenefiterDTO> benefiterMapper)
    : IDTOService<Expense, ExpenseDTO>
{
    private readonly IDTOService<UserBenefiter, UserBenefiterDTO> _benefiterMapper = benefiterMapper;

    /// <inheritdoc/>
    public ExpenseDTO Map(Expense entity)
    {
        var benefiterDTOs = new Collection<UserBenefiterDTO>();

        ArgumentNullException.ThrowIfNull(entity);

        if (entity.Benefiters == null)
        {
            // TODO entity.Benefiters as exception param????
            throw new ArgumentNullException(nameof(entity), "EntityBenefiters is null");
        }

        foreach (var b in entity.Benefiters)
        {
            benefiterDTOs.Add(_benefiterMapper.Map(b));
        }

        return new ExpenseDTO(entity.Amount, benefiterDTOs, entity.Title, entity.UserID);
    }

    /// <inheritdoc/>
    public Expense Map(ExpenseDTO dto)
    {
        var benefiters = new List<UserBenefiter>();
        ArgumentNullException.ThrowIfNull(dto);
        if (dto.Benefiters == null)

            // TODO dto.Benefiters as exception param???
            throw new ArgumentNullException(nameof(dto), "dto Benefiters is null.");

        foreach (var b in dto.Benefiters)
        {
            benefiters.Add(_benefiterMapper.Map(b));
        }

        return new Expense(dto.Title, dto.Amount, dto.UserID, benefiters);
    }
}