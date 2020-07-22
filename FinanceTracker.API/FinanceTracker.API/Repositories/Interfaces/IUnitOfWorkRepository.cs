using FinanceTracker.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.API.Repositories.Interfaces
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IDataContext Context { get; }
        Task<int> SaveChanges();
    }
}
