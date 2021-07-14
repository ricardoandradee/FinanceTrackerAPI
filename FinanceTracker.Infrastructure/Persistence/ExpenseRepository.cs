using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Persistence
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(IUnitOfWorkRepository unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<IList<Expense>> GetExpensesByUserId(int userId)
        {
            var expenses = await _unitOfWork.Context.Expenses.Where(b => b.Category.User.Id == userId)
                .Include(c => c.Category)
                .Include(c => c.Currency)
                .Include(t => t.Transaction)
                        .ThenInclude(a => a.Account)
                .ToListAsync();

            return expenses;
        }

        public async Task<bool> BelongsToUser(int userId, int expenseId)
        {
            return await _unitOfWork.Context.Expenses.AnyAsync(b => b.Id == expenseId && b.Category.User.Id == userId);
        }
    }
}
