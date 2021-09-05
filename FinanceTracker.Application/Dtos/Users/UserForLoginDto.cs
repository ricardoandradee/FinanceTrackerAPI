using System;

namespace FinanceTracker.Application.Dtos.Users
{
    public class UserForLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}