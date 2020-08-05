using FinanceTracker.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Repositories.Interfaces
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IDataContext Context { get; }
        Task<int> SaveChanges();
    }
}
