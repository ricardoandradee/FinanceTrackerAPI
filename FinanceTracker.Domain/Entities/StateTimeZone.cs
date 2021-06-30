using System;
using System.Collections.Generic;

namespace FinanceTracker.Domain.Entities
{
    public class StateTimeZone
    {
        public int Id { get; set; }
        public string UTC { get; set; }
        public string Description { get; set; }
        public string TimeZoneInfoId { get; set; }
        public bool SupportsDaylightSavingTime { get; set; }
    }
}