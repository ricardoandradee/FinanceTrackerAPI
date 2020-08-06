using FinanceTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesByUserId(int userId);
        Task<bool> ExistsAnyPaymentsConnectedToCategory(int categoryId);
        Task<bool> BelongsToUser(int userId, int categoryId);
    }
}