using Microsoft.AspNetCore.Mvc;
using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

namespace SplitProject.API.Controllers
{
    [ApiController]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IDbCrudService _dbCrudService;
        private readonly IDtoService<Expense, ExpenseDTO> _dtoService;
        public ExpenseController(IExpenseService expenseService, IDbCrudService dbCrudService, IDtoService<Expense, ExpenseDTO> dtoService)
        {
            _expenseService = expenseService;
            _dbCrudService = dbCrudService;
            _dtoService = dtoService;
        }

        [HttpPost("NewExpense")]
        public ActionResult NewExpense(ExpenseDTO newExpense)
        {
            Expense entityExpense = _dtoService.ToEntity(newExpense);
            _dbCrudService.AddEntity<Expense>(entityExpense);
            _expenseService.CountExpense(entityExpense.Amount, entityExpense.UserId, entityExpense.Benefiters);
            return Ok();
        }

        [HttpGet("GetExpense")]
        public ExpenseDTO GetExpense(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                Expense expense = _dbCrudService.GetEntityById<Expense>(Id);
                ExpenseDTO expenseDto = _dtoService.ToDto(expense);
                return expenseDto;
            }
            else
            {
                throw new ArgumentException("Wrong Id");
            }
        }

        /*
        [HttpPost("NewExpense")]
        public string NewExpense(string jsonForm)
        {
            Expense newExpense = JsonConvert.DeserializeObject<Expense>(jsonForm);

            using (SplitContext db = new())
            {
                //Expense newexpense = jsonFormDeserialized; //Приведение к объекту класса Экспенс, Бенефитерсы включены

                db.Expenses.Add(newExpense);
                db.SaveChanges();
            }
            IExpenseService expenseService = new ExpenseService();
            expenseService.CountExpense(newExpense.ExpenseAmount, newExpense.UserId, newExpense.Benefiters);
            return newExpense.ExpenseId;
        } */
    }
}