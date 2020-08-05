using System;

namespace FinanceTracker.Business.Dtos
{
    public class CategoryForCreationDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
