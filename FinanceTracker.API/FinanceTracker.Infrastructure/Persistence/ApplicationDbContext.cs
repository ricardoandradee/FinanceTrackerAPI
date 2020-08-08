using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private IDbContextTransaction _currentTransaction;
        private readonly IUserResolverService _userResolverService;
        internal int _currentUserId { get; private set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
                                    IUserResolverService userResolverService) : base(options) {
            _userResolverService = userResolverService;
            _currentUserId = GetCurrentUserId();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await (this as DbContext).SaveChangesAsync();
        }

        DbSet<TEntity> IApplicationDbContext.Set<TEntity>()
        {
            return this.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);

            builder.Entity<Bank>()
            .HasQueryFilter(bank => bank.UserId == _currentUserId);

            builder.Entity<Account>()
            .HasQueryFilter(account => account.Bank.UserId == _currentUserId);

            builder.Entity<Transaction>()
            .HasQueryFilter(transaction => transaction.Account.Bank.UserId == _currentUserId);

            builder.Entity<Expense>()
            .HasQueryFilter(expense => expense.Category.UserId == _currentUserId);

            builder.Entity<Category>()
            .HasQueryFilter(category => category.UserId == _currentUserId);

            builder.Entity<Wallet>()
            .HasQueryFilter(wallet => wallet.UserId == _currentUserId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ReplaceService<IModelCacheKeyFactory, UserCacheKeyFactory>();
        }

        private int GetCurrentUserId()
        {
            var userClaims = _userResolverService.GetUserClaimsPrincipal();
            var currentUserId = 0;
            if (userClaims != null)
            {
                currentUserId = int.Parse(userClaims.GetUserId() ?? "0");
            }
            return currentUserId;
        }
    }
}
