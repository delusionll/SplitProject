using SplitProject.Domain.Models;

namespace SplitProject.DAL
{
    public interface IDbCRUD
    {
        public static User GetUserById(int id)
        {
            using (SplitContext _db = new())
            {
                User entity = _db.Users.Find(id);
                return entity;
            }
        }

        public static void DeleteUserById(int id)
        {
            using (SplitContext _db = new())
            {
                _db.Users.Remove(GetUserById(id));
                _db.SaveChanges();
            }
        }

        public static void DeleteAllUsers()
        {
            using (SplitContext _db = new())
            {
                foreach (User u in _db.Users)
                {
                    _db.Users.Remove(u);
                }
                _db.SaveChanges();
            }
        }
    }
}
