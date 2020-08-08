using System;

namespace FinanceTracker.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Address { get; set; }
        public string Establishment { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public decimal AmountPaid { get; set; }
        public virtual Transaction Transaction { get; set; }
        public int TransactionId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
