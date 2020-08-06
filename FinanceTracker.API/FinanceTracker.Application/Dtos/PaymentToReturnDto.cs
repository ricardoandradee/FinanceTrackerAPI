using System;

namespace FinanceTracker.Application.Dtos
{
    public class PaymentToReturnDto
    {
        public int Id { get; set; }
        public String CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Address { get; set; }
        public string Establishment { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedDateString { get; set; }
    }
}
