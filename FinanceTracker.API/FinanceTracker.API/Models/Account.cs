using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime? CreatedDate { get; set; }
    }
}
