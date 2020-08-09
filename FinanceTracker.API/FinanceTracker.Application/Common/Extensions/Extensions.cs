using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceTracker.Application.Common.Extensions
{
    public static class Extensions
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
    }
}
