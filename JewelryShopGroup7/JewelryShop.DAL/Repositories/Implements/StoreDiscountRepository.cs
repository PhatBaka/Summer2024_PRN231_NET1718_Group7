using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JewelryShop.DAL.Repositories.Implements
{
    public class StoreDiscountRepository : IStoreDiscountRepository
    {
        private readonly AppDbContext _dbContext;

        public StoreDiscountRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(StoreDiscount entity)
        {
            await _dbContext.StoreDiscounts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.StoreDiscountId;
        }

        public async Task<IQueryable<StoreDiscount>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.StoreDiscounts.AsQueryable());
        }

        public async Task<IQueryable<StoreDiscount>> GetAsync(Expression<Func<StoreDiscount, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.StoreDiscounts.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(StoreDiscount entity)
        {
            _dbContext.StoreDiscounts.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StoreDiscount entity)
        {
            _dbContext.StoreDiscounts.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<StoreDiscount> GetFirstOrDefaultAsync(Expression<Func<StoreDiscount, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.StoreDiscounts.FirstOrDefault(predicate));
        }
    }
}
