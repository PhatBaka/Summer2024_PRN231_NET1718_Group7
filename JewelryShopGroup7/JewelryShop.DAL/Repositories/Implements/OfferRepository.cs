using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JewelryShop.DAL.Repositories.Implement
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AppDbContext _dbContext;

        public OfferRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(Offer entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.OfferId;
        }

        public async Task<IQueryable<Offer>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Offers.AsQueryable());
        }

        public async Task<IQueryable<Offer>> GetAsync(Expression<Func<Offer, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Offers.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(Offer entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Offer entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Offer> GetFirstOrDefaultAsync(Expression<Func<Offer, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Offers.FirstOrDefault(predicate));
        }
    }
}
