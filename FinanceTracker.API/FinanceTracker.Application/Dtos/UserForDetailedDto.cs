using System;

namespace FinanceTracker.Application.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastActive { get; set; }
        public string TimeZone { get; set; }
        public string Country { get; set; }
        
    }
}