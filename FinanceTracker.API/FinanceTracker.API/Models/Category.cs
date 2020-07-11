using System;

namespace FinanceTracker.API.Models
{
    public class Category
    {

        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
