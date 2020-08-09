using System;

namespace FinanceTracker.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
