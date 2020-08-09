using FinanceTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<Expense> Expenses { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Bank> Banks { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<Wallet> Wallets { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<StateTimeZone> StateTimeZones { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        void RollbackTransaction();
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync();
    }
}