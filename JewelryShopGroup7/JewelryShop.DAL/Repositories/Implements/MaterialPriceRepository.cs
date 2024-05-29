using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DAL.Repositories.Implements
{
    public class MaterialPriceRepository : IMaterialPriceRepository
    {
        private readonly AppDbContext _dbContext;

        public MaterialPriceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(MaterialPrice entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.MaterialPriceId;
        }

        public async Task<IQueryable<MaterialPrice>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.MaterialPrices.AsQueryable());
        }

        public async Task<IQueryable<MaterialPrice>> GetAsync(Expression<Func<MaterialPrice, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.MaterialPrices.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(MaterialPrice entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MaterialPrice entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<MaterialPrice> GetFirstOrDefaultAsync(Expression<Func<MaterialPrice, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.MaterialPrices.FirstOrDefault(predicate));
        }
    }
}
