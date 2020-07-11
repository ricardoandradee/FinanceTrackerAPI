using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinanceTracker.API.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> RetrieveById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Add(TEntity entity);
        Task<bool> AddRange(IEnumerable<TEntity> entities);
        Task<bool> Delete(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> DeleteRange(IEnumerable<TEntity> entities);
    }
}