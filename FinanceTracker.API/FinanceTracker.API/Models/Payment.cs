using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models
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
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public virtual Transaction Transaction { get; set; }
        public int TransactionId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
