namespace SplitProject.API.Controllers;

using System;
using Microsoft.AspNetCore.Mvc;
using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

/// <summary>
/// Expense controller.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ExpenseController"/> class.
/// </remarks>
/// <param name="expenseService">expense service instance.</param>
/// <param name="crudService">CRUD service instance.</param>
/// <param name="dtoService">DTO service instance.</param>
[ApiController]
public class ExpenseController(
    IExpenseService expenseService, ICRUDService crudService, IDTOService<Expense, ExpenseDTO> dtoService) : Controller
{
    private readonly ICRUDService _crudService = crudService;
    private readonly IDTOService<Expense, ExpenseDTO> _dtoService = dtoService;
    private readonly IExpenseService _expenseService = expenseService;

    /// <summary>
    /// Get Expense by expense ID.
    /// </summary>
    /// <param name="id">Expense ID.</param>
    /// <returns>Expense DTO.</returns>
    /// <exception cref="ArgumentException">wrong ID.</exception>
    [HttpGet("/GetExpense")]
    public ExpenseDTO GetExpense(Guid id)
    {
        if (id != Guid.Empty)
        {
            var expense = _crudService.GetById<Expense>(id);
            var expenseDto = _dtoService.Map(expense);
            return expenseDto;
        }

        throw new ArgumentException("Wrong Id");
    }

    /// <summary>
    /// Create a new expense.
    /// </summary>
    /// <param name="newExpense">new expense DTO.</param>
    /// <returns>OK if expense counted.</returns>
    [HttpPost("/NewExpense")]
    public ActionResult NewExpense(ExpenseDTO newExpense)
    {
        var expEnt = _dtoService.Map(newExpense);
        _crudService.Add(expEnt);

        // TODO count on expense property change.
        _expenseService.Count(expEnt.Amount, _crudService.GetById<User>(expEnt.UserID), expEnt.Benefiters);
        return Ok();
    }
}