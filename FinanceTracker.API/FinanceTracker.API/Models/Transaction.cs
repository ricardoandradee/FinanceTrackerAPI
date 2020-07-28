using System;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.API.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        [MaxLength(10)]
        public string Action { get; set; }
        public virtual Account Account { get; set; }
        public int AccountId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}