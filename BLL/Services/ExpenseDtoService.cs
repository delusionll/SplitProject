﻿namespace BLL.Services;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BLL.DTO;
using BLL.IServices;
using Domain.Models;

/// <summary>
/// Expense DTO.
/// </summary>
public class ExpenseDTOService(IDTOService<UserBenefiter, UserBenefiterDTO> benefiterMapper)
    : IDTOService<Expense, ExpenseDTO>
{
    private readonly IDTOService<UserBenefiter, UserBenefiterDTO> _benefiterMapper = benefiterMapper;

    /// <inheritdoc/>
    public ExpenseDTO Map(Expense entity)
    {
        var benefiterDTOs = new Collection<UserBenefiterDTO>();
        if (entity.Benefiters == null)

            // TODO entity.Benefiters as exception param????
            throw new ArgumentNullException(nameof(entity));

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
        if (dto.Benefiters == null)

            // TODO dto.Benefiters as exception param???
            throw new ArgumentNullException(nameof(dto));

        foreach (var b in dto.Benefiters)
        {
            benefiters.Add(_benefiterMapper.Map(b));
        }

        return new Expense(dto.Title, dto.Amount, dto.UserID, benefiters);
    }
}