using System;

namespace FinanceTracker.Application.Dtos.Users
{
    public class UserForRegisterDto
    {
        public UserForRegisterDto()
        {
            CreatedDate = DateTimeOffset.UtcNow;
            LastActive = DateTime.UtcNow;
        }

        public string UserName { get; set; }
        public string BaseCurrency { get; set; }
        public decimal Wallet { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TimeZone { get; set; }
        public string Country { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastActive { get; set; }

    }
}