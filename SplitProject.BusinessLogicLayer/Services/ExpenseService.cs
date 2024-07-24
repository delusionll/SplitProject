namespace SplitProject.BLL.Services;

using System.Collections.ObjectModel;
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
        decimal amount, Guid userIdFrom, Collection<Benefiter> benefitersList) // Counting expense, updates DB
    {
        var userFrom = _dbCrud.GetEntityById<User>(userIdFrom);
        userFrom.Balance += amount;
        var totalPercent = 0;
        foreach (var b in benefitersList)
        {
            var userToBenefit = _dbCrud.GetEntityById<User>(b.Id);
            userToBenefit.Balance -= amount * b.Percent / 100;
            totalPercent += b.Percent;
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