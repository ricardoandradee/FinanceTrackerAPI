using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceTracker.Business.Data;
using FinanceTracker.Business.Models;
using FinanceTracker.Business.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Business.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWorkRepository unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<bool> BelongsToUser(int userId, int categoryId)
        {
            return await _unitOfWork.Context.Categories.AnyAsync(c => c.Id == categoryId && c.User.Id == userId);
        }

        public async Task<bool> ExistsAnyPaymentsConnectedToCategory(int categoryId)
        {
            return await _unitOfWork.Context.Payments.AnyAsync(u => u.Category.Id == categoryId);
        }

        public async Task<IEnumerable<Category>> GetCategoriesForUser(int userId)
        {
            var categories = await _unitOfWork.Context.Categories.Where(u => u.User.Id == userId).ToListAsync();
            return categories;
        }
    }
}