namespace API.Controllers;

using System;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<ExpenseDTO>> GetExpenseAsync(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest("Wrong ID");

        var expense = await _crudService.GetByIdAsync<Expense>(id).ConfigureAwait(false);
        if (expense.Value == null)
            return NotFound($"Expense id {id} not found");

        var expenseDto = _dtoService.Map(expense.Value);
        return Ok(expenseDto);
    }

    /// <summary>
    /// Create a new expense.
    /// </summary>
    /// <param name="newExpense">new expense DTO.</param>
    /// <returns>OK if expense counted. <see cref="ExpenseDTO"/>.</returns>
    [HttpPost("/NewExpense")]
    public async Task<IActionResult> NewExpense(ExpenseDTO newExpense)
    {
        if (newExpense == null)
            return BadRequest("Expense data is required.");

        try
        {
            var result = await _expenseService.CreateAsync(newExpense);
            return Ok(_dtoService.Map(result));
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return BadRequest("Internal server failure");
        }
    }
}