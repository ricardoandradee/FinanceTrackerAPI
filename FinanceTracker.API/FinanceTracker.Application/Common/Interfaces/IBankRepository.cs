using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IBankRepository : IUserVerification, IRepository<Bank>
    {
        Task<IEnumerable<Bank>> GetBanksByUserId(int userId);
        Task<IEnumerable<Account>> GetAllAccounts(int bankId);
        Task<Bank> CreateBankWithAccount(Bank bank);
    }
}
