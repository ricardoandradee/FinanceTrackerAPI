using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Persistence
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

        public async Task<IEnumerable<Category>> GetCategoriesByUserId(int userId)
        {
            var categories = await _unitOfWork.Context.Categories.Where(u => u.User.Id == userId).ToListAsync();
            return categories;
        }
    }
}