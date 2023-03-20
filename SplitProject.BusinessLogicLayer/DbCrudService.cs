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
        private readonly SplitContext _context;
        public DbCrudService(SplitContext context)
        {
            _context = context;
        }

        public User GetUserById(Guid id)
        {
            User entity = _context.Users.Find(id);
            return entity;
        }

        public void DeleteUserById(Guid id)
        {
                _context.Users.Remove(GetUserById(id));
                _context.SaveChanges();
        }

        public void DeleteAllUsers()
        {
                foreach (User u in _context.Users)
                {
                    _context.Users.Remove(u);
                }
                _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
