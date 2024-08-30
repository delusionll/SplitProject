namespace SplitProject.BLL.Services;

using System;
using System.Collections.Generic;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

/// <summary>
/// Expense service.
/// </summary>
public class ExpenseService : IExpenseService
{
    private readonly IDbCrudService _dbCrud;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpenseService"/> class.
    /// </summary>
    /// <param name="dbCrud">CRUService instance.</param>
    public ExpenseService(IDbCrudService dbCrud)
    {
        _dbCrud = dbCrud;
    }

    /// <inheritdoc/>
    public void CountExpense(
        decimal amount, Guid userIdFrom, IEnumerable<KeyValuePair<User, int>> benefitersList) // Counting expense, updates DB
    {
        var userFrom = _dbCrud.GetEntityById<User>(userIdFrom);
        userFrom.Balance += amount;
        var totalPercent = 0;
        foreach (var b in benefitersList)
        {
            var userToBenefit = _dbCrud.GetEntityById<User>(b.Key.Id);
            userToBenefit.Balance -= amount * b.Value / 100;
            totalPercent += b.Value;
        }

        if (totalPercent == 100)
        {
            _dbCrud.SaveChanges();
        }
        else
        {
            throw new ArgumentException("wrong percent Sum");
        }
    }
}