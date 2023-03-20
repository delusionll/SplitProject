using SplitProject.DAL;
using SplitProject.Domain.Models;

namespace SplitProject.BLL
{
    public interface IDbCrudService
    {
        public User GetUserById(Guid Id);
        public void DeleteUserById(Guid id);
        public void DeleteAllUsers();

    }
}
