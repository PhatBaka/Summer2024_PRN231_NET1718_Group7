﻿using System.Linq.Expressions;

namespace JewelryShop.DAL.Repositories;

public interface IRepositoryBase<TEntity>
{
    Task<IQueryable<TEntity>> GetAllAsync();
    Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<Guid> AddAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
}
