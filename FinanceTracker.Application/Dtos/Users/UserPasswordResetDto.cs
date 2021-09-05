using System;

namespace FinanceTracker.Application.Dtos.Users
{
    public class UserPasswordResetDto
    {
        public int UserId { get; set; }
        public Guid? ConfirmationCode { get; set; }
        public string Password { get; set; }
    }
}