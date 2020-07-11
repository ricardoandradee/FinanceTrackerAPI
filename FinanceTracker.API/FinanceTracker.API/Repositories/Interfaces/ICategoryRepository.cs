using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceTracker.API.Models;

namespace FinanceTracker.API.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesForUser(int userId);
        Task<bool> ExistsAnyPaymentsConnectedToCategory(int categoryId);
        Task<bool> CategoryBelongsToUser(int userId, int categoryId);
    }
}