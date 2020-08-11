using FinanceTracker.Application.Common.Models;
using System;

namespace FinanceTracker.Application.Dtos.Users
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public Response<UserForDetailDto> User { get; set; }
    }
}