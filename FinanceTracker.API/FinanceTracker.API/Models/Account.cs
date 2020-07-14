using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models
{
    public class Account
    {
        public int Id { get; set; }
        public virtual Bank Bank { get; set; }
        public int BankId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
