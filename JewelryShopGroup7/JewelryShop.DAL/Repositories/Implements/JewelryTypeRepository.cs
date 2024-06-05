using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JewelryShop.DAL.Repositories.Implements
{
    public class JewelryTypeRepository : IJewelryTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public JewelryTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(JewelryType entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.TypeId;
        }

        public async Task<IQueryable<JewelryType>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.JewelryTypes.AsQueryable());
        }

        public async Task<IQueryable<JewelryType>> GetAsync(Expression<Func<JewelryType, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.JewelryTypes.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(JewelryType entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(JewelryType entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<JewelryType> GetFirstOrDefaultAsync(Expression<Func<JewelryType, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.JewelryTypes.FirstOrDefault(predicate));
        }
    }
}
