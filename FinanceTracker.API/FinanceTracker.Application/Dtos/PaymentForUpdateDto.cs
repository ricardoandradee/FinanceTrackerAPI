using System;

namespace FinanceTracker.Application.Dtos
{
    public class PaymentForUpdateDto
    {
        public int CategoryId { get; set; }
        public string Address { get; set; }
        public string Establishment { get; set; }
        public string Description { get; set; }
        public decimal AmountPaid { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
    }
}
