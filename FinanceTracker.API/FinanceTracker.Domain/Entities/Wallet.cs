using System;

namespace FinanceTracker.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
