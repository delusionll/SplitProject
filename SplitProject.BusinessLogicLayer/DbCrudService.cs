using SplitProject.DAL;
using SplitProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitProject.BLL
{
    public class DbCrudService : IDbCrudService
    {
        public User GetUserById(Guid id)
        {
            using (SplitContext _db = new())
            {
                User entity = _db.Users.Find(id);
                return entity;
            }
        }

        public void DeleteUserById(Guid id)
        {
            using (SplitContext _db = new())
            {
                _db.Users.Remove(GetUserById(id));
                _db.SaveChanges();
            }
        }

        public void DeleteAllUsers()
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
