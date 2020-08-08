using System;

namespace FinanceTracker.Application.Dtos.Users
{
    public class UserForLoginDto
    {
        public UserForLoginDto()
        {
            LastActive = DateTime.Now;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime LastActive { get; set; }
    }
}