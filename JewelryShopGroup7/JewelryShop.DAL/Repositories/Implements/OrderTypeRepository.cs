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
    public class OrderTypeRepository : IOrderTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(OrderType entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.OrderTypeId;
        }

        public async Task<IQueryable<OrderType>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.OrderTypes);
        }

        public async Task<IQueryable<OrderType>> GetAsync(Expression<Func<OrderType, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.OrderTypes.Where(predicate));
        }

        public async Task RemoveAsync(OrderType entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderType entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<OrderType> GetFirstOrDefaultAsync(Expression<Func<OrderType, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.OrderTypes.FirstOrDefault(predicate));
        }
    }
}
