using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JewelryShop.DAL.Repositories.Implement
{
    public class JewelryMaterialRepository : IJewelryMaterialRepository
    {
        private readonly AppDbContext _dbContext;

        public JewelryMaterialRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<JewelryMaterial> GetFirstOrDefaultAsync(Expression<Func<JewelryMaterial, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.JewelryMaterials.FirstOrDefault(predicate));
        }

        public async Task<Guid> AddAsync(JewelryMaterial entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return new Guid();
        }

        public async Task<IQueryable<JewelryMaterial>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.JewelryMaterials.AsQueryable());
        }

        public async Task<IQueryable<JewelryMaterial>> GetAsync(Expression<Func<JewelryMaterial, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.JewelryMaterials.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(JewelryMaterial entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(JewelryMaterial entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
