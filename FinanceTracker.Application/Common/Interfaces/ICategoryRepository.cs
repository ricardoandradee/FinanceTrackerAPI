using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface ICategoryRepository : IUserVerification, IRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesByUserId(int userId);
        Task<bool> ExistsAnyExpensesConnectedToCategory(int categoryId);
    }
}