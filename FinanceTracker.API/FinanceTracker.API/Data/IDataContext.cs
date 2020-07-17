using System;
using System.Threading.Tasks;
using FinanceTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Data
{
    public interface IDataContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Bank> Banks { get; set; }
        DbSet<Account> Accounts { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}