using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DAL.Repositories.Implement
{
    public class GuaranteeRepository : IGuaranteeRepository
    {
        private readonly AppDbContext _dbContext;

        public GuaranteeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(Guarantee entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.GuaranteeId;
        }

        public async Task<Guarantee> GetFirstOrDefaultAsync(Expression<Func<Guarantee, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Guarantees.FirstOrDefault(predicate));
        }
        public async Task<IQueryable<Guarantee>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Guarantees.AsQueryable());
        }

        public async Task<IQueryable<Guarantee>> GetAsync(Expression<Func<Guarantee, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Guarantees.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(Guarantee entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guarantee entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
