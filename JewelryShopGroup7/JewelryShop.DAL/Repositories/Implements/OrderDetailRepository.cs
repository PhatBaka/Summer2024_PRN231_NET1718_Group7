using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JewelryShop.DAL.Repositories.Implements
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderDetailRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(OrderDetail entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.OrderDetailId;
        }

        public async Task<IQueryable<OrderDetail>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.OrderDetails.AsQueryable());
        }

        public async Task<IQueryable<OrderDetail>> GetAsync(Expression<Func<OrderDetail, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.OrderDetails.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(OrderDetail entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDetail entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<OrderDetail> GetFirstOrDefaultAsync(Expression<Func<OrderDetail, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.OrderDetails.FirstOrDefault(predicate));
        }
    }
}
