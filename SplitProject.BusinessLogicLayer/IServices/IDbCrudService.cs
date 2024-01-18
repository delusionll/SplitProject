namespace SplitProject.BLL.IServices;

public interface IDbCrudService
{
	T GetEntityById<T>(Guid Id) where T : class;

	//public User GetUserById(Guid Id);
	//public Expense GetExpenseById(Guid Id);
	void DeleteEntityById<T>(Guid Id) where T : class;

	//public void DeleteUserById(Guid Id);
	//public void DeleteExpenseById(Guid Id);
	void DeleteAllEntityes<T>() where T : class;

	//public void DeleteAllUsers();
	//public void DeleteAllExpenses();
	//public void AddUser(User user);
	//public void AddExpense(Expense expense);
	void AddEntity<T>(T entity) where T : class;
	void SaveChanges();
}