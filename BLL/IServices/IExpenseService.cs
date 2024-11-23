namespace BLL.IServices;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using DTOs;

/// <summary>
/// Service to work with expenses.
/// </summary>
public interface IExpenseService
{
    /// <summary>
    /// <see langword="method"/> to count expense.
    /// </summary>
    /// <param name="amount">        expense amount.</param>
    /// <param name="fromUser">      user who did the expense.</param>
    /// <param name="benefitersList">list of users to benefit.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    ValueTask CountAsync(
        decimal amount, User fromUser, IEnumerable<UserBenefiter> benefitersList);

    /// <summary>
    /// Create and count expense.
    /// </summary>
    /// <param name="expenseDTO">expense DTO.</param>
    /// <returns>Expense entity.</returns>
    ValueTask CreateAsync(ExpenseDTO expenseDTO);

    /// <summary>
    /// Gets ExpenseDTO by id.
    /// </summary>
    /// <param name="id">expense id.</param>
    /// <returns>taska.</returns>
    ValueTask<ExpenseDTO?> GetByIdAsync(Guid id);
}