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
        public AccountRepository(IDataContext context)
            : base(context)
        {
        }
        
        public async Task<IEnumerable<Account>> GetAccountsForBank(int bankId)
        {
            var accounts = await _context.Accounts.Where(a => a.Bank.Id == bankId).ToListAsync();
            return accounts;
        }

        public async Task<bool> BelongsToUser(int userId, int accountId)
        {
            return await _context.Accounts.AnyAsync(a => a.Id == accountId && a.Bank.User.Id == userId);
        }
    }
}
