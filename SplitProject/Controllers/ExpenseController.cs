namespace SplitProject.API.Controllers;

using BLL.DTO;
using BLL.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ExpenseController : Controller
{
    private readonly IDbCrudService _dbCrudService;
    private readonly IDtoService<Expense, ExpenseDTO> _dtoService;
    private readonly IExpenseService _expenseService;

    public ExpenseController(IExpenseService expenseService, IDbCrudService dbCrudService,
        IDtoService<Expense, ExpenseDTO> dtoService)
    {
        _expenseService = expenseService;
        _dbCrudService = dbCrudService;
        _dtoService = dtoService;
    }

    [HttpPost("NewExpense")]
    public ActionResult NewExpense(ExpenseDTO newExpense)
    {
        var entityExpense = _dtoService.ToEntity(newExpense);
        _dbCrudService.AddEntity(entityExpense);
        _expenseService.CountExpense(entityExpense.Amount, entityExpense.UserId, entityExpense.Benefiters);
        return Ok();
    }

    [HttpGet("GetExpense")]
    public ExpenseDTO GetExpense(Guid Id)
    {
        if (Id != Guid.Empty)
        {
            var expense = _dbCrudService.GetEntityById<Expense>(Id);
            var expenseDto = _dtoService.ToDto(expense);
            return expenseDto;
        }

        throw new ArgumentException("Wrong Id");
    }
}