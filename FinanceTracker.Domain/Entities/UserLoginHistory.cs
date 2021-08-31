using System;

namespace FinanceTracker.Domain.Entities
{
    public class UserLoginHistory
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public DateTimeOffset ActionDateTime { get; set; }
        public bool IsSuccessful { get; set; }
        public string IPAddress { get; set; }
        public string GeoLocation { get; set; }
    }
}