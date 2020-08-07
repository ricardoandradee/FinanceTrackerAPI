using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Application.Common.Extensions
{
    public static class Calculations
    {
        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddDays(age) > DateTime.Today)
                age--;

            return age;
        }
    }
}
