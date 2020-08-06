using System;
//using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Domain.Entities
{
    public class Category
    {

        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        //[MaxLength(50)]
        public string Name { get; set; }
        //[MaxLength(255)]
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
