using FinanceTracker.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Repositories.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetAccountsTransactions(int accountId);
        Task<Transaction> PerformAccountTransaction(Transaction transaction);
    }
}
