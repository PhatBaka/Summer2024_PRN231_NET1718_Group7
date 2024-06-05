using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JewelryShop.DAL.Repositories.Implements
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly AppDbContext _dbContext;

        public MaterialRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(Material entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.MaterialId;
        }

        public async Task<IQueryable<Material>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Materials.AsQueryable());
        }

        public async Task<IQueryable<Material>> GetAsync(Expression<Func<Material, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Materials.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(Material entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Material entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Material> GetFirstOrDefaultAsync(Expression<Func<Material, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Materials.FirstOrDefault(predicate));
        }
    }
}
