using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Commands.Users
{
    public class UserLocationDetailsDto
    {
        public string Ip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postal { get; set; }
        public string Timezone { get; set; }
        public string Loc { get; set; }

        public override string ToString()
        {
            return $"Location: {Loc} | " +
                    $"City: {City}-{Country} | " +
                    $"ZipCode: {Postal} | Timezone: {Timezone}";
        }
    }
}
