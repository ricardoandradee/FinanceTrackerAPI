using System;

namespace FinanceTracker.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public virtual Category Category { get; set; }
        public string Address { get; set; }
        public string Establishment { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public virtual Transaction Transaction { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
