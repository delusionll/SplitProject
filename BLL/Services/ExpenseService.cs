namespace BLL.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.IServices;
using DAL;
using Domain;
using DTOs;

/// <summary>
/// Expense service.
/// </summary>
/// <remarks>
/// Initializes a new instance of the
/// <see cref="ExpenseService"/> class.
/// </remarks>
/// <param name="repository">CRUService instance.</param>
public class ExpenseService(
    IRepository repository, IDTOService<Expense, ExpenseDTO> expenseDTOService)
    : IExpenseService
{
    private readonly IDTOService<Expense, ExpenseDTO> _expenseDTOService = expenseDTOService;
    private readonly IRepository _repository = repository;

    /// <inheritdoc/>
    // TODO update DB dependency;
    public async ValueTask CountAsync(
        decimal amount,
        User fromUser,
        IEnumerable<UserBenefiter> benefitersList)
    {
        fromUser.Balance += amount;
        int totalPercent = 0;
        foreach (var b in benefitersList)
        {
            var userToBenefit = await _repository
                .GetByIdAsync<User>(b.User.UserID).ConfigureAwait(false);
            if (userToBenefit == null)
            {
                throw new Exception("user not found");
            }

            userToBenefit.Balance -= amount * b.Share / 100;
            totalPercent += b.Share;
        }

        // TODO TEST 100 percent
        await _repository.SaveChangesAsync().ConfigureAwait(false);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">
    /// throws if user is null.
    /// </exception>
    public async ValueTask CreateAsync(ExpenseDTO expenseDTO)
    {
        var expense = _expenseDTOService.Map(expenseDTO);
        await _repository.AddAsync(expense).ConfigureAwait(false);

        var user = await _repository
            .GetByIdAsync<User>(expense.UserID).ConfigureAwait(false);
        if (user == null)
        {
            throw new Exception("user not found");
        }

        await CountAsync(
            expense.Amount, user, expense.Benefiters).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async ValueTask<ExpenseDTO?> GetByIdAsync(Guid id)
    {
        var exp = await _repository.GetByIdAsync<Expense>(id)
            .ConfigureAwait(false);
        return exp == null ? null : _expenseDTOService.Map(exp);
    }
}