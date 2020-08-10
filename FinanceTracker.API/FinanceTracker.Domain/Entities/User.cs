using System;
using System.Collections.Generic;

namespace FinanceTracker.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
        public virtual StateTimeZone StateTimeZone { get; set; }
        public int StateTimeZoneId { get; set; }
        public string Country { get; set; }
    }
}
