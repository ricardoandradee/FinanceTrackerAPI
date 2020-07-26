using FinanceTracker.API.Data;
using FinanceTracker.API.Models;
using FinanceTracker.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.API.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IUnitOfWorkRepository unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Transaction>> GetAccountsTransactions(int accountId)
        {
            var transactions = await _unitOfWork.Context.Transactions.Where(t => t.Account.Id == accountId).ToListAsync();
            return transactions;
        }
    }
}
