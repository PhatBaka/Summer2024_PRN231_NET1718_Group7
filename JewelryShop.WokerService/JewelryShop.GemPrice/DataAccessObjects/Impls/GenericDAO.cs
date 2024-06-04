using JewelryShop.GemPrice.DataAccessObjects.Interfaces;
using JewelryShop.GemPrice.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JewelryShop.GemPrice.DataAccessObjects.Impls
{
    public class GenericDAO<TEntity> : IGenericDAO<TEntity> where TEntity : class
    {
        private readonly AppDBContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericDAO(AppDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> FindAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await Task.Run(() => _dbSet.SingleOrDefault(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding entity: {ex.Message}", ex);
            }
        }

        public async Task<IQueryable<TEntity>> FindAll(Func<TEntity, bool> predicate)
        {
            try
            {
                return await Task.Run(() => _dbSet.Where(predicate).AsQueryable());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding all entities: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _dbSet.SingleOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding entity: {ex.Message}", ex);
            }
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            try
            {
                return await Task.Run(() => _dbSet.AsQueryable());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all entities: {ex.Message}", ex);
            }
        }

        public async Task DeleteRangeAsync(IQueryable<TEntity> entities)
        {
            try
            {
                _dbSet.RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting range of entities: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity by ID: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await Task.Run(() => _dbSet.Where(predicate).AsEnumerable());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entities by predicate: {ex.Message}", ex);
            }
        }

        public async Task<bool> HardDeleteAsync(object key)
        {
            try
            {
                var entity = await _dbSet.FindAsync(key);
                if (entity == null)
                {
                    return false;
                }
                _dbSet.Remove(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error hard deleting entity: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting entity: {ex.Message}", ex);
            }
        }

        public async Task<bool> HardDeleteIdAsync(object key)
        {
            try
            {
                return await HardDeleteAsync(key);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error hard deleting entity by ID: {ex.Message}", ex);
            }
        }

        public async Task<bool> InsertAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting entity: {ex.Message}", ex);
            }
        }

        public async Task<bool> InsertRangeAsync(IQueryable<TEntity> entities)
        {
            try
            {
                await _dbSet.AddRangeAsync(entities);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting range of entities: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateByIdAsync(TEntity entity, object id)
        {
            try
            {
                var existingEntity = await _dbSet.FindAsync(id);
                if (existingEntity == null)
                {
                    return false;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating entity by ID: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateRangeAsync(IQueryable<TEntity> entities)
        {
            try
            {
                _dbSet.UpdateRange(entities);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating range of entities: {ex.Message}", ex);
            }
        }

        public async Task<bool> AnyAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await Task.Run(() => _dbSet.Any(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking if any entity matches predicate: {ex.Message}", ex);
            }
        }

        public async Task<int> CountAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await Task.Run(() => _dbSet.Count(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error counting entities by predicate: {ex.Message}", ex);
            }
        }

        public async Task<int> CountAsync()
        {
            try
            {
                return await _dbSet.CountAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error counting entities: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> FistOrDefault(Func<TEntity, bool> predicate)
        {
            try
            {
                return await Task.Run(() => _dbSet.FirstOrDefault(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding first or default entity: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error finding first or default entity: {ex.Message}", ex);
            }
        }

        public async Task<bool> SaveChagesAysnc()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving changes: {ex.Message}", ex);
            }
        }

        public async Task<bool> IsMinAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await Task.Run(() => _dbSet.Min(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking if entity is min: {ex.Message}", ex);
            }
        }

        public async Task<bool> IsMaxAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await Task.Run(() => _dbSet.Max(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking if entity is max: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> GetMinAsync()
        {
            try
            {
                return await Task.Run(() => _dbSet.Min());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting min entity: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> GetMaxAsync()
        {
            try
            {
                return await Task.Run(() => _dbSet.Max());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting max entity: {ex.Message}", ex);
            }
        }

        public async Task<bool> IsMaxAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await Task.Run(() => _dbSet.Max(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking if entity is max: {ex.Message}", ex);
            }
        }

        public async Task<bool> IsMinAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await Task.Run(() => _dbSet.Min(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking if entity is min: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> GetMinAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await Task.Run(() => _dbSet.Where(predicate).Min());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting min entity: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> GetMaxAsync(Func<TEntity, bool> predicate)
        {
            try
            {
                return await Task.Run(() => _dbSet.Where(predicate).Max());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting max entity: {ex.Message}", ex);
            }
        }
    }
}
