using System;

namespace FinanceTracker.Application.Dtos.Categories
{
    public class CategoryForCreationDto
    {
        public CategoryForCreationDto()
        {
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
