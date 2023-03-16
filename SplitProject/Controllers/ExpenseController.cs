using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SplitProject.BLL;
using SplitProject.DataBase;
using SplitProject.Models;

namespace SplitProject.API.Controllers
{
    [ApiController]
    public class ExpenseController : Controller
    {
        [HttpPost("NewExpense")]
        public string NewExpense(string jsonForm)
        {
            Expense newexpense = JsonConvert.DeserializeObject<Expense>(jsonForm);

            using (SplitContext db = new())
            {
                //Expense newexpense = jsonFormDeserialized; //Приведение к объекту класса Экспенс, Бенефитерсы включены

                db.Expenses.Add(newexpense);
                db.SaveChanges();
            }
            IBLL.CountExpense(newexpense.ExpenseAmount, newexpense.UserId, newexpense.Benefiters);
            return $"Expense counted with Id #{newexpense.ExpenseId}";
        }
    }
}