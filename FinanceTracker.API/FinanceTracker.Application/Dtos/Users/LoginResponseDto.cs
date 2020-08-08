using System;

namespace FinanceTracker.Application.Dtos.Users
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public UserForListDto User { get; set; }
    }
}