using System;

namespace FinanceTracker.Business.Dtos
{
    public class CategoryToReturnDto
    {
        public CategoryToReturnDto()
        {
            CanBeDeleted = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool CanBeDeleted { get; set; }
    }
}
