using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IAccountRepository : IUserVerification, IRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccountsForBank(int bankId);
        Task<Account> CreateAccount(Account account);
    }
}
