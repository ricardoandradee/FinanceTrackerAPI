using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        //[MaxLength(255)]
        public string Address { get; set; }
        //[MaxLength(50)]
        public string Establishment { get; set; }
        //[MaxLength(255)]
        public string Description { get; set; }
        //[MaxLength(3)]
        public string Currency { get; set; }
        //[Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        //[ForeignKey("TransactionId")]
        public virtual Transaction Transaction { get; set; }
        public int? TransactionId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
