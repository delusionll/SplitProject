namespace SplitProject.BLL.IServices;

public interface IDbCrudService
{
    void AddEntity<T>(T entity) where T : class;

    void DeleteAllEntityes<T>() where T : class;

    void DeleteEntityById<T>(Guid Id) where T : class;

    T GetEntityById<T>(Guid Id) where T : class;

    void SaveChanges();
}