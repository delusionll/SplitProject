namespace BLL.IServices;

using System.Collections.Generic;
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
    void Count(decimal amount, User fromUser, IEnumerable<UserBenefiter> benefitersList);
}