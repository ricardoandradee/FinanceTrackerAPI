using FinanceTracker.Application.Dtos.Currencies;
using FinanceTracker.Application.Dtos.TimeZones;
using System;

namespace FinanceTracker.Application.Dtos.Users
{
    public class UserForDetailDto
    {
        public int Id { get; set; }
        public CurrencyDto Currency { get; set; }
        public StateTimeZoneToReturnDto StateTimeZone { get; set; }
        public decimal Wallet { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Guid? ConfirmationCode { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastActive { get; set; }

    }
}