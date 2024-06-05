using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JewelryShop.DAL.Repositories.Implements
{
    public class JewelryRepository : IJewelryRepository
    {
        private readonly AppDbContext _dbContext;

        public JewelryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Jewelry> GetFirstOrDefaultAsync(Expression<Func<Jewelry, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Jewelries.FirstOrDefault(predicate));
        }
        public async Task<Guid> AddAsync(Jewelry entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.JewelryId;
        }

        public async Task<IQueryable<Jewelry>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Jewelries.AsQueryable());
        }

        public async Task<IQueryable<Jewelry>> GetAsync(Expression<Func<Jewelry, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Jewelries.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(Jewelry entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Jewelry entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
