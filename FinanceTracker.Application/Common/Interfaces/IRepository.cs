using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinanceTracker.Application.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> RetrieveById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}