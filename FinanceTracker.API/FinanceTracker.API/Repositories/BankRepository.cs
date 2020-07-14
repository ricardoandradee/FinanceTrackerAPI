using FinanceTracker.API.Data;
using FinanceTracker.API.Models;
using FinanceTracker.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.API.Repositories
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        public BankRepository(DataContext context)
            : base(context)
        {
        }
        
        public async Task<IEnumerable<Bank>> GetBanksForUser(int userId)
        {
            var banks = await _context.Banks.Where(u => u.User.Id == userId).ToListAsync();
            return banks;
        }

        public async Task<bool> BelongsToUser(int userId, int bankId)
        {
            return await _context.Banks.AnyAsync(c => c.Id == bankId && c.User.Id == userId);
        }

        public async Task<IEnumerable<Account>> GetAllAccounts(int bankId)
        {
            return await _context.Accounts.Where(a => a.Bank.Id == bankId).ToListAsync();
        }
    }
}
