using FinanceTracker.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Business.Repositories.Interfaces
{
    public interface IBankRepository : IRepository<Bank>
    {
        Task<IEnumerable<Bank>> GetBanksForUser(int userId);
        Task<IEnumerable<Account>> GetAllAccounts(int bankId);
        Task<bool> BelongsToUser(int userId, int bankId);
        Task<Bank> CreateBankWithAccount(Bank bank);
    }
}
