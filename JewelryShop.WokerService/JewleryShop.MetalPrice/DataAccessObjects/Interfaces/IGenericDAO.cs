﻿using System.Linq.Expressions;

namespace JewleryShop.MetalPrice.DataAccessObjects.Interfaces
{
	public interface IGenericDAO<TEntity> where TEntity : class
	{
		public Task<TEntity> FindAsync(Func<TEntity, bool> predicate);
		public Task<IQueryable<TEntity>> FindAll(Func<TEntity, bool> predicate);
		public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
		public Task<IQueryable<TEntity>> GetAllAsync();
		public Task DeleteRangeAsync(IQueryable<TEntity> entities);
		public Task<TEntity> GetByIdAsync(object id);
		public Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);
		public Task<bool> HardDeleteAsync(object key);
		public Task<bool> DeleteAsync(TEntity entity);
		public Task<bool> HardDeleteIdAsync(object key);
		public Task<bool> InsertAsync(TEntity entity);
		public Task<bool> InsertRangeAsync(IQueryable<TEntity> entities);
		public Task<bool> UpdateByIdAsync(TEntity entity, object id);
		public Task<bool> UpdateRangeAsync(IQueryable<TEntity> entities);
		public Task<bool> AnyAsync(Func<TEntity, bool> predicate);
		public Task<int> CountAsync(Func<TEntity, bool> predicate);
		public Task<int> CountAsync();
		public Task<TEntity> FistOrDefault(Func<TEntity, bool> predicate);
		public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
		public Task<bool> SaveChagesAysnc();
		public Task<bool> IsMinAsync(Func<TEntity, bool> predicate);
		public Task<bool> IsMaxAsync(Func<TEntity, bool> predicate);
		public Task<TEntity> GetMinAsync();
		public Task<TEntity> GetMaxAsync();
		public Task<bool> IsMaxAsync(Expression<Func<TEntity, bool>> predicate);
		public Task<bool> IsMinAsync(Expression<Func<TEntity, bool>> predicate);
		public Task<TEntity> GetMinAsync(Func<TEntity, bool> predicate);
		public Task<TEntity> GetMaxAsync(Func<TEntity, bool> predicate);
	}
}
