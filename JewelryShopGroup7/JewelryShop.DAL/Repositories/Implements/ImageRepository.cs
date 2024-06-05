using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JewelryShop.DAL.Repositories.Implements
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDbContext _dbContext;

        public ImageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddAsync(Image entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.ImageId;
        }

        public async Task<Image> GetFirstOrDefaultAsync(Expression<Func<Image, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Images.FirstOrDefault(predicate));
        }
        public async Task<IQueryable<Image>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.Images.AsQueryable());
        }

        public async Task<IQueryable<Image>> GetAsync(Expression<Func<Image, bool>> predicate)
        {
            return await Task.FromResult(_dbContext.Images.Where(predicate).AsQueryable());
        }

        public async Task RemoveAsync(Image entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Image entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}