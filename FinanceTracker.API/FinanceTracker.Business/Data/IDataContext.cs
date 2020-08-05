using System;
using System.Threading.Tasks;
using FinanceTracker.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FinanceTracker.Business.Data
{
    public interface IDataContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Bank> Banks { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<Wallet> Wallets { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync();
    }
}