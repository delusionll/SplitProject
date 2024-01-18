namespace SplitProject.BLL.IServices;

public interface IDbCrudService
{
	T GetEntityById<T>(Guid Id) where T : class;

	void DeleteEntityById<T>(Guid Id) where T : class;
	void DeleteAllEntityes<T>() where T : class;
	void AddEntity<T>(T entity) where T : class;
	void SaveChanges();
}