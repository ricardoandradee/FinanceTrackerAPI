using System;

namespace FinanceTracker.Application.Dtos.Categories
{
    public class CategoryToReturnDto
    {
        public CategoryToReturnDto()
        {
            CanBeDeleted = false;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public bool CanBeDeleted { get; set; }
    }
}
