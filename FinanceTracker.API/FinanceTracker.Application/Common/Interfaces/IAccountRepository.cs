using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccountsForBank(int bankId);
        Task<bool> BelongsToUser(int userId, int accountId);
        Task<Account> CreateAccount(Account account);
    }
}
