using FinanceTracker.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.API.Repositories.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetAccountsTransactions(int accountId);
    }
}
