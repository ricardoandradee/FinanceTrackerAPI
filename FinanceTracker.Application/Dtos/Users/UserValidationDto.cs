using System;

namespace FinanceTracker.Application.Dtos.Users
{
    public class UserValidationDto
    {
        public int UserId { get; set; }
        public Guid? ConfirmationCode { get; set; }
    }
}