using System;

namespace FinanceTracker.Application.Dtos.Users
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string Country { get; set; }
        
    }
}