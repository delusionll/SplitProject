namespace SplitProject.BLL.IServices;

using System.Collections.ObjectModel;
using SplitProject.Domain.Models;

/// <summary>
/// Service to work with expenses.
/// </summary>
public interface IExpenseService
{
    /// <summary>
    /// <see langword="method"/> to count expense.
    /// </summary>
    /// <param name="amount">expense amount.</param>
    /// <param name="userIdFrom">user ID who did the expense.</param>
    /// <param name="benefitersList">list of users to benefit.</param>
    void CountExpense(decimal amount, Guid userIdFrom, Collection<Benefiter> benefitersList);
}