using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JewelryShop.DAL.Repositories.Implements
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _dbContext;

        public AccountRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(Account entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.AccountId;
        }

        public async Task<IQueryable<Account>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Accounts);
        }

        public async Task<IQueryable<Account>> GetAsync(Expression<Func<Account, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Accounts.Where(predicate));
        }

        public async Task<Account> GetFirstOrDefaultAsync(Expression<Func<Account, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Accounts.FirstOrDefault(predicate));
        }

        public async Task RemoveAsync(Account entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
