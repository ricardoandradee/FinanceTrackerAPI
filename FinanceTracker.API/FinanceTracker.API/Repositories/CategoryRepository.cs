using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceTracker.API.Data;
using FinanceTracker.API.Models;
using FinanceTracker.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context)
            : base(context)
        {
        }

        public async Task<bool> CategoryBelongsToUser(int userId, int categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.Id == categoryId && c.User.Id == userId);
        }

        public async Task<bool> ExistsAnyPaymentsConnectedToCategory(int categoryId)
        {
            return await _context.Payments.AnyAsync(u => u.Category.Id == categoryId);
        }

        public async Task<IEnumerable<Category>> GetCategoriesForUser(int userId)
        {
            var categories = await _context.Categories.Where(u => u.User.Id == userId).ToListAsync();
            return categories;
        }
    }
}