using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Infrastructure.Persistence
{
    internal class UserCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
        {
            if (context is ApplicationDbContext applicationContext)
            {
                return (context.GetType(), applicationContext._currentUserId);
            }

            return context.GetType();
        }
    }
}
