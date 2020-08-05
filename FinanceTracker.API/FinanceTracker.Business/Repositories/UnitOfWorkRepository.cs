using FinanceTracker.Business.Data;
using FinanceTracker.Business.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IDataContext Context { get; }

        public UnitOfWorkRepository(IDataContext context)
        {
            Context = context;
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
