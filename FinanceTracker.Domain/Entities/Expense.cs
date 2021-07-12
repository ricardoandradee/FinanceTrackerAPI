using System;

namespace FinanceTracker.Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Establishment { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public decimal Price { get; set; }
        public bool IsPaid { get; set; }
        public virtual Transaction Transaction { get; set; }
        public int? TransactionId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
