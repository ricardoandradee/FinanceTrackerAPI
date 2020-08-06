using System;

namespace FinanceTracker.Application.Dtos
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public UserForListDto User { get; set; }
    }
}