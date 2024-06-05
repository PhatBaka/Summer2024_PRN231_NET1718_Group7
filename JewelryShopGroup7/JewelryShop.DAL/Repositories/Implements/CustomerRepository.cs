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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> GetFirstOrDefaultAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Customers.FirstOrDefault(predicate));
        }

        public async Task<Guid> AddAsync(Customer entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.CustomerId;
        }

        public async Task<IQueryable<Customer>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Customers);
        }

        public async Task<IQueryable<Customer>> GetAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Customers.Where(predicate));
        }

        public async Task RemoveAsync(Customer entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
