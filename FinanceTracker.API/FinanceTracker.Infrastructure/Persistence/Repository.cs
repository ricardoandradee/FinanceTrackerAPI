using FinanceTracker.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinanceTracker.Infrastructure.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWorkRepository _unitOfWork;
        public Repository(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _unitOfWork.Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> RetrieveById(int id)
        {
            return await _unitOfWork.Context.Set<TEntity>().FindAsync(id);
        }

        public async Task Add(TEntity entity)
        {
            await _unitOfWork.Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await _unitOfWork.Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Delete(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _unitOfWork.Context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _unitOfWork.Context.Set<TEntity>().Where(predicate).ToListAsync();
        }
    }
}