using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceTracker.Business.Models;

namespace FinanceTracker.Business.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesByUserId(int userId);
        Task<bool> ExistsAnyPaymentsConnectedToCategory(int categoryId);
        Task<bool> BelongsToUser(int userId, int categoryId);
    }
}