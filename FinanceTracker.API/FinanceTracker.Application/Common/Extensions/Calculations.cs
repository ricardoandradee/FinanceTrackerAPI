using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceTracker.Application.Common.Extensions
{
    public static class Calculations
    {
        public static IEnumerable<List<T>> SplitList<T>(this List<T> source, int chunksize)
        {
            var pos = 0;
            while (source.Skip(pos).Any())
            {
                yield return source.Skip(pos).Take(chunksize).ToList();
                pos += chunksize;
            }
        }

        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddDays(age) > DateTime.Today)
                age--;

            return age;
        }
    }
}
