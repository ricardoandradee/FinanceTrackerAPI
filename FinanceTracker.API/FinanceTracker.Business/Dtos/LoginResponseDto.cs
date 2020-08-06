using System;

namespace FinanceTracker.Business.Dtos
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public UserForListDto User { get; set; }
    }
}