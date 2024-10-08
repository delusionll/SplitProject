﻿namespace BLL.IServices;

using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO;
using Domain.Models;

/// <summary>
/// Service to work with expenses.
/// </summary>
public interface IExpenseService
{
    /// <summary>
    /// <see langword="method"/> to count expense.
    /// </summary>
    /// <param name="amount">expense amount.</param>
    /// <param name="fromUser">user who did the expense.</param>
    /// <param name="benefitersList">list of users to benefit.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task CountAsync(decimal amount, User fromUser, IEnumerable<UserBenefiter> benefitersList);

    /// <summary>
    /// Create and count expense.
    /// </summary>
    /// <param name="expenseDTO">expense DTO.</param>
    /// <returns>Expense entity.</returns>
    Task<Expense> CreateAsync(ExpenseDTO expenseDTO);
}