using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IExpenseRepository : IUserVerification, IRepository<Expense>
    {
        Task<IList<Expense>> GetExpensesByUserId(int userId);
    }
}
