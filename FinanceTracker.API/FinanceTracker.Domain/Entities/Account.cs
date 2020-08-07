using System;
using System.Collections.Generic;

namespace FinanceTracker.Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }
        public string Currency { get; set; }
        public decimal CurrentBalance { get; set; }
        public virtual Bank Bank { get; set; }
        public int BankId { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
