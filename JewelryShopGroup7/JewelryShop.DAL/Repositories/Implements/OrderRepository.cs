using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JewelryShop.DAL.Repositories.Implements
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(Order entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.OrderId;
        }

        public async Task<IQueryable<Order>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Orders.AsQueryable());
        }

        public async Task<IQueryable<Order>> GetAsync(Expression<Func<Order, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Orders.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(Order entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order> GetFirstOrDefaultAsync(Expression<Func<Order, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Orders.FirstOrDefault(predicate));
        }
    }
}
