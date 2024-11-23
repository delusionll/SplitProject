namespace BLL.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.IServices;
using Domain;

/// <summary>
/// Expense service.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ExpenseService"/> class.
/// </remarks>
/// <param name="crudService">CRUService instance.</param>
public class ExpenseService(ICRUDService crudService, IDTOService<Expense, ExpenseDTO> expenseDTOService)
    : IExpenseService
{
    private readonly ICRUDService _crudService = crudService;
    private readonly IDTOService<Expense, ExpenseDTO> _expenseDTOService = expenseDTOService;

    /// <inheritdoc/>
    // TODO update DB dependency
    // Counting expense, updates DB
    public async Task CountAsync(
        decimal amount, User fromUser, IEnumerable<UserBenefiter> benefitersList)
    {
        fromUser.Balance += amount;
        int totalPercent = 0;
        foreach (var b in benefitersList)
        {
            var userToBenefit = await _crudService.GetByIdAsync<User>(b.User.UserID).ConfigureAwait(false);
            if (userToBenefit == null)
            {
                throw new Exception("User not found");
            }

            userToBenefit.Value.Balance -= amount * b.Share / 100;
            totalPercent += b.Share;
        }

        if (totalPercent == 100)
        {
            await _crudService.SaveChangesAsync().ConfigureAwait(false);
        }
        else
        {
            throw new ArgumentException("wrong share Sum");
        }
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">throws if user is null.</exception>
    public async Task<Expense> CreateAsync(ExpenseDTO expenseDTO)
    {
        var expense = _expenseDTOService.Map(expenseDTO);
        await _crudService.AddAsync(expense).ConfigureAwait(false);
        var user = await _crudService.GetByIdAsync<User>(expense.UserID).ConfigureAwait(false);
        if (user.Value == null)
            throw new ArgumentNullException(nameof(user));
        await CountAsync(expense.Amount, user.Value, expense.Benefiters).ConfigureAwait(false);
        return expense;
    }
}