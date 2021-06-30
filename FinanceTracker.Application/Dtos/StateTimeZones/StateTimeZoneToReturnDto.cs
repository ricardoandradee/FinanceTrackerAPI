using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Dtos.TimeZones
{
    public class StateTimeZoneToReturnDto
    {
        public int Id { get; set; }
        public string UTC { get; set; }
        public string Description { get; set; }
        public string TimeZoneInfoId { get; set; }
        public bool SupportsDaylightSavingTime { get; set; }
        public bool IsDaylightSaving
        {
            get
            {
                if (!SupportsDaylightSavingTime
                        || string.IsNullOrWhiteSpace(TimeZoneInfoId))
                {
                    return false;
                }

                return TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfoId)
                                   .IsDaylightSavingTime(DateTime.Now);
            }
        }
    }
}
