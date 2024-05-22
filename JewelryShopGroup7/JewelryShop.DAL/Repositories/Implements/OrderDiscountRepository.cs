using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JewelryShop.DAL.Repositories.Implement
{
    public class OrderDiscountRepository : IOrderDiscountRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderDiscountRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(OrderDiscount entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.OrderDiscountId;
        }

        public async Task<IQueryable<OrderDiscount>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.OrderDiscounts.AsQueryable());
        }

        public async Task<IQueryable<OrderDiscount>> GetAsync(Expression<Func<OrderDiscount, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.OrderDiscounts.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(OrderDiscount entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDiscount entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
