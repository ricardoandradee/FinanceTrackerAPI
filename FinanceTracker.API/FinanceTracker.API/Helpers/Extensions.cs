using System;

namespace FinanceTracker.API.Helpers
{
    public static class Extensions
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
