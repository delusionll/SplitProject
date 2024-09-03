namespace SplitProject.BLL.Services;

using System;
using System.Collections.Generic;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

/// <summary>
/// Expense service.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ExpenseService"/> class.
/// </remarks>
/// <param name="dbCrud">CRUService instance.</param>
public class ExpenseService(ICRUDService dbCrud) : IExpenseService
{
    private readonly ICRUDService _dbCrud = dbCrud;

    /// <inheritdoc/>
    // TODO update DB dependency
    // Counting expense, updates DB
    public void Count(
        decimal amount, User fromUser, IEnumerable<UserBenefiter> benefitersList)
    {
        fromUser.Balance += amount;
        int totalPercent = 0;
        foreach (var b in benefitersList)
        {
            var userToBenefit = _dbCrud.GetById<User>(b.User.UserID);
            userToBenefit.Balance -= amount * b.Share / 100;
            totalPercent += b.Share;
        }

        if (totalPercent == 100)
        {
            _dbCrud.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("wrong share Sum");
        }
    }
}