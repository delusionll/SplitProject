﻿using SplitProject.Domain.Models;

namespace SplitProject.BLL
{
    public interface IDbCrudService
    {
        public User GetUserById(Guid Id);
        public void DeleteUserById(Guid id);
        public void DeleteAllUsers();
        public void AddExpense(Expense expense);
        public void SaveChanges();

    }
}
