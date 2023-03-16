using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SplitProject.BLL;

namespace SplitProject.API.Controllers
{
    [ApiController]
    public class ExpenseController : Controller
    {
        [HttpPost("NewExpense")]
        public string NewExpense(string jsonForm)
        {
            Expense newExpense = JsonConvert.DeserializeObject<Expense>(jsonForm);

            using (SplitContext db = new())
            {
                //Expense newexpense = jsonFormDeserialized; //Приведение к объекту класса Экспенс, Бенефитерсы включены

                db.Expenses.Add(newexpense);
                db.SaveChanges();
            }
            IExpenseService expenseService = new ExpenseService();
            expenseService.CountExpense(newExpense.ExpenseAmount, newExpense.UserId, newExpense.Benefiters);
            return $"Expense counted with Id #{newExpense.ExpenseId}";
        }
    }
}