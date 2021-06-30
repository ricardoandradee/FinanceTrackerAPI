using FinanceTracker.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Persistence
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public IApplicationDbContext Context { get; }

        public UnitOfWorkRepository(IApplicationDbContext context)
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
