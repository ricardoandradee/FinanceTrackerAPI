using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IBankRepository : IRepository<Bank>
    {
        Task<IEnumerable<Bank>> GetBanksByUserId(int userId);
        Task<IEnumerable<Account>> GetAllAccounts(int bankId);
        Task<bool> BelongsToUser(int userId, int bankId);
        Task<Bank> CreateBankWithAccount(Bank bank);
    }
}
