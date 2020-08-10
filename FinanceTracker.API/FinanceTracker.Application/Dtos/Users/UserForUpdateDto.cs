using System;

namespace FinanceTracker.Application.Dtos.Users
{
    public class UserForUpdateDto
    {
        public int CurrencyId { get; set; }
        public string Country { get; set; }
        public int StateTimeZoneId { get; set; }

    }
}