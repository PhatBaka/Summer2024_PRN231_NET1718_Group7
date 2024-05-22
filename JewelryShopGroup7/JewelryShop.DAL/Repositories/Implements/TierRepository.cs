using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JewelryShop.DAL.Repositories.Implements
{
    public class TierRepository : ITierRepository
    {
        private readonly AppDbContext _dbContext;

        public TierRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(Tier entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.TierId;
        }

        public async Task<IQueryable<Tier>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Tiers);
        }

        public async Task<IQueryable<Tier>> GetAsync(Expression<Func<Tier, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Tiers.Where(predicate));
        }

        public async Task RemoveAsync(Tier entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tier entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
