using FinanceTracker.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Repositories.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccountsForBank(int bankId);
        Task<bool> BelongsToUser(int userId, int accountId);
        Task<Account> CreateAccount(Account account);
    }
}
