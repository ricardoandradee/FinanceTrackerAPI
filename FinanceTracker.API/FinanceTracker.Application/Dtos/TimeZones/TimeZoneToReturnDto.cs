using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Dtos.TimeZones
{
    public class StateTimeZoneToReturnDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string UTC { get; set; }
        public string Description { get; set; }
    }
}
