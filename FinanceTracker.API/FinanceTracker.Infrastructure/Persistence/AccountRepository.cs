using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Persistence
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

        public async Task<Account> CreateAccount(Account account)
        {
            var bankIdParam = new SqlParameter("bankId", account.BankId);
            var accountNameParam = new SqlParameter("accountName", account.Name);
            var accountNumberParam = new SqlParameter("accountNumber", account.Number);
            var accountCurrencyParam = new SqlParameter("accountCurrency", account.AccountCurrency);
            var currentBalanceParam = new SqlParameter("currentBalance", account.CurrentBalance);
            var createdDateParam = new SqlParameter("createdDate", account.CreatedDate.ToString("yyyy-MM-ddTHH:mm:ss"));
            var accountIdParam = new SqlParameter("accountId", DbType.Int32) { Direction = ParameterDirection.Output };

            await _unitOfWork.Context.Database
                       .ExecuteSqlRawAsync(@"Exec CreateAccount @bankId, @accountName, @accountNumber, @accountCurrency, " +
                       "@currentBalance, @createdDate, @accountId Out"
                  , new[] { bankIdParam, accountNameParam, accountNumberParam, accountCurrencyParam,
                    currentBalanceParam, createdDateParam, accountIdParam });

            return await RetrieveById(Convert.ToInt32(accountIdParam.Value));
        }
    }
}
