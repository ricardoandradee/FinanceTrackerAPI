using System;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IApplicationDbContext Context { get; }
        Task<int> SaveChanges();
    }
}
