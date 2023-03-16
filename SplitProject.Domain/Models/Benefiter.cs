﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SplitProject.Domain.Models
{
    public class Benefiter
    {
        [Key]
        public int Id { get; set; }

        public int BenefiterPercent { get; set; }
        public int UserId { get; set; } //Внешний ключ к Юзерам
        public int ExpenseId { get; set; } //Внешний ключ к таблице Expense
        [JsonIgnore]
        public Expense Expense { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        public Benefiter(int percent, int userToBenefitId)
        {
            BenefiterPercent = percent;
            UserId = userToBenefitId;
        }

        public Benefiter()
        { }
    }
}