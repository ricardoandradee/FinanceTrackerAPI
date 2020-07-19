using System.Threading.Tasks;
using FinanceTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await (this as DbContext).SaveChangesAsync();
        }

        DbSet<TEntity> IDataContext.Set<TEntity>()
        {
            return this.Set<TEntity>();
        }
    }
}
