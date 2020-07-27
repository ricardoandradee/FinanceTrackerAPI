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
        public BankRepository(IUnitOfWorkRepository unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<Bank>> GetBanksForUser(int userId)
        {
            var banks = await _unitOfWork.Context.Banks.Where(b => b.User.Id == userId)
            .Include(a => a.Accounts)
            .ToListAsync();
            return banks;
        }

        public async Task<bool> BelongsToUser(int userId, int bankId)
        {
            return await _unitOfWork.Context.Banks.AnyAsync(c => c.Id == bankId && c.User.Id == userId);
        }

        public async Task<IEnumerable<Account>> GetAllAccounts(int bankId)
        {
            return await _unitOfWork.Context.Accounts.Where(a => a.Bank.Id == bankId).ToListAsync();
        }
    }
}
