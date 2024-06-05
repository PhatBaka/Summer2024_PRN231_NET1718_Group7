using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JewelryShop.DAL.Repositories.Implements
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _dbContext;

        public RoleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(Role entity)
        {
            await _dbContext.Roles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.RoleId;
        }

        public async Task<IQueryable<Role>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Roles.AsQueryable());
        }

        public async Task<IQueryable<Role>> GetAsync(Expression<Func<Role, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Roles.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(Role entity)
        {
            _dbContext.Roles.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role entity)
        {
            _dbContext.Roles.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Role> GetFirstOrDefaultAsync(Expression<Func<Role, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Roles.FirstOrDefault(predicate));
        }
    }
}
