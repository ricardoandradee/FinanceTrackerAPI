using FinanceTracker.Application.Dtos.Currencies;
using FinanceTracker.Application.Dtos.TimeZones;
using System;

namespace FinanceTracker.Application.Dtos.Users
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public CurrencyToReturnDto Currency { get; set; }
        public StateTimeZoneToReturnDto StateTimeZone { get; set; }
        public decimal Wallet { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastActive { get; set; }
        public string Country { get; set; }
    }
}