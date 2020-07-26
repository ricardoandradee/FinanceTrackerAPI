using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.API.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(3)]
        public string AccountCurrency { get; set; }
        public decimal CurrentBalance { get; set; }
        public virtual Bank Bank { get; set; }
        public int BankId { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
