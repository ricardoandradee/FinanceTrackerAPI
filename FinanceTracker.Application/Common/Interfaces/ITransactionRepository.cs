using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetTransactionsByAccountId(int accountId);
        Task<Transaction> PerformAccountTransaction(Transaction transaction);
    }
}
