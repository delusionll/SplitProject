﻿using SplitProject.DAL;
using SplitProject.Domain.Models;

namespace SplitProject.BLL
{
    public interface IBLL
    {
        public static void CountExpense(decimal amount, Guid userIdFrom, List<Benefiter> benefitersList) //Counting expense, updates DB
        {
            using (SplitContext _db = new())
            {
                {
                    User userFrom = _db.Users.Find(userIdFrom);
                    userFrom.UserBalance += amount;
                    double totalPercent = 0;
                    foreach (Benefiter b in benefitersList)
                    {
                        User userToBenefit = _db.Users.Find(b.UserId);
                        userToBenefit.UserBalance -= amount * b.BenefiterPercent / 100;
                        totalPercent += b.BenefiterPercent;
                    }
                    if (totalPercent == 100)
                    {
                        _db.SaveChanges();

                    }
                    else
                    {
                        throw new ArgumentException("wrong percent Sum");
                    }

                }
            }
        }
    }
}
