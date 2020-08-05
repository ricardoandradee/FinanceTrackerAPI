using System;

namespace FinanceTracker.Business.Dtos
{
    public class PaymentForCreationDto
    {
        public int CategoryId { get; set; }
        public string Address { get; set; }
        public string Establishment { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
