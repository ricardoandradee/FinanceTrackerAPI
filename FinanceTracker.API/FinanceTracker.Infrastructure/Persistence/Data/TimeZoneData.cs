using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceTracker.Infrastructure.Persistence.Data
{
    public static class TimeZoneData
    {        
        private static string GetUTCFromDisplayName(string displayName)
        {
            var idxOpenRoundBracket = displayName.IndexOf('(');
            var idxCloseRoundBracket = displayName.IndexOf(')');

            var utcTime = displayName.Substring(idxOpenRoundBracket + 1, idxCloseRoundBracket - 1);
            return utcTime.Replace("UTC", string.Empty);
        }
        
        public static List<StateTimeZone> GetTimeZoneList()
        {
            var timeZones = (from i in TimeZoneInfo.GetSystemTimeZones()
                            select new StateTimeZone
                            {
                                TimeZoneInfoId = i.Id,
                                Description = i.DisplayName,
                                SupportsDaylightSavingTime = i.SupportsDaylightSavingTime,
                                UTC = GetUTCFromDisplayName(i.DisplayName)
                            }).ToList();

            return timeZones;
        }
    }
}