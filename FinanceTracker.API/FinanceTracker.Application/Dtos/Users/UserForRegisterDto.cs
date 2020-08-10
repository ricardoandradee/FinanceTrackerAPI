using System;

namespace FinanceTracker.Application.Dtos.Users
{
    public class UserForRegisterDto
    {
        public UserForRegisterDto()
        {
            CreatedDate = DateTimeOffset.UtcNow;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public int CurrencyId { get; set; }
        public decimal Wallet { get; set; }
        public string Password { get; set; }
        public int StateTimeZoneId { get; set; }
        public string Country { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}