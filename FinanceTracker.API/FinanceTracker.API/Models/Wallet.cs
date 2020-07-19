using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(3)]
        public string AccountCurrency { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
