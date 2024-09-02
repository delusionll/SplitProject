namespace SplitProject.API.Controllers;

using System;
using Microsoft.AspNetCore.Mvc;
using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

/// <summary>
/// Expense controller.
/// </summary>
[ApiController]
public class ExpenseController : Controller
{
    private readonly ICRUDService _dbCrudService;

    private readonly IDTOService<Expense, ExpenseDTO> _dtoService;

    private readonly IExpenseService _expenseService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpenseController"/> class.
    /// </summary>
    /// <param name="expenseService">expense service instance.</param>
    /// <param name="dbCrudService">CRUD service instance.</param>
    /// <param name="dtoService">DTO service instance.</param>
    public ExpenseController(
        IExpenseService expenseService, ICRUDService dbCrudService, IDTOService<Expense, ExpenseDTO> dtoService)
    {
        _expenseService = expenseService;
        _dbCrudService = dbCrudService;
        _dtoService = dtoService;
    }

    /// <summary>
    /// Get Expense by expense ID.
    /// </summary>
    /// <param name="id">Expense ID.</param>
    /// <returns>Expense DTO.</returns>
    /// <exception cref="ArgumentException">wrong ID.</exception>
    [HttpGet("GetExpense")]
    public ExpenseDTO GetExpense(Guid id)
    {
        if (id != Guid.Empty)
        {
            var expense = _dbCrudService.GetById<Expense>(id);
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
    [HttpPost("NewExpense")]
    public ActionResult NewExpense(ExpenseDTO newExpense)
    {
        var entityExpense = _dtoService.Map(newExpense);
        _dbCrudService.Add(entityExpense);
        _expenseService.CountExpense(entityExpense.Amount, entityExpense.UserId, entityExpense.Benefiters);
        return Ok();
    }
}