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
        public ExpenseController(IExpenseService expenseService, IDbCrudService dbCrudService)
        {
            _expenseService = expenseService;
            _dbCrudService = dbCrudService;
        }

        [HttpPost("NewExpense")]
        public Guid NewExpense(Expense newExpense)
        {
            _dbCrudService.AddExpense(newExpense);
            _expenseService.CountExpense(newExpense.ExpenseAmount, newExpense.UserId, newExpense.Benefiters);
            return newExpense.Id;
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