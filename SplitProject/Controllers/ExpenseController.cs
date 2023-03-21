using Microsoft.AspNetCore.Mvc;
using SplitProject.BLL;
using SplitProject.Domain.Models;

namespace SplitProject.API.Controllers
{
    [ApiController]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IDbCrudService _dbCrudService;
        private readonly IDtoService _dtoService;
        public ExpenseController(IExpenseService expenseService, IDbCrudService dbCrudService, IDtoService dtoService)
        {
            _expenseService = expenseService;
            _dbCrudService = dbCrudService;
            _dtoService = dtoService;
        }

        [HttpPost("NewExpense")]
        public Guid NewExpense(ExpenseDTO newExpense)
        {
            Expense entityExpense = _dtoService.ExpenseDtoToEntity(newExpense);
            _dbCrudService.AddExpense(entityExpense);
            _expenseService.CountExpense(entityExpense.ExpenseAmount, entityExpense.UserId, entityExpense.Benefiters);
            return entityExpense.Id;
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