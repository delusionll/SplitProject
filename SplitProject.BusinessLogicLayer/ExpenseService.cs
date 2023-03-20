﻿using SplitProject.Domain.Models;

namespace SplitProject.BLL
{
    public class ExpenseService : IExpenseService
    {
        private readonly IDbCrudService _dbCrud;
        public ExpenseService(DbCrudService dbCrud)
        {
            _dbCrud = dbCrud;
        }

        public void CountExpense(decimal amount, Guid userIdFrom, List<BenefiterDTO> benefitersList) //Counting expense, updates DB
        {
            User userFrom = _dbCrud.GetUserById(userIdFrom);
            userFrom.UserBalance += amount;
            int totalPercent = 0;
            foreach (BenefiterDTO b in benefitersList)
            {
                User userToBenefit = _dbCrud.GetUserById(b.Id);
                userToBenefit.UserBalance -= amount * b.BenefiterPercent / 100;
                totalPercent += b.BenefiterPercent;
            }
            if (totalPercent == 100)
            {
                _dbCrud.SaveChanges();

            }
            else
            {
                throw new ArgumentException("wrong percent Sum");
            }
        }
    }
}
