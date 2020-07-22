using FinanceTracker.API.Data;
using FinanceTracker.API.Models;
using FinanceTracker.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.API.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(IUnitOfWorkRepository unitOfWork)
            : base(unitOfWork)
        {
        }
        
        public async Task<IEnumerable<Account>> GetAccountsForBank(int bankId)
        {
            var accounts = await _unitOfWork.Context.Accounts.Where(a => a.Bank.Id == bankId).ToListAsync();
            return accounts;
        }

        public async Task<bool> BelongsToUser(int userId, int accountId)
        {
            return await _unitOfWork.Context.Accounts.AnyAsync(a => a.Id == accountId && a.Bank.User.Id == userId);
        }
    }
}
