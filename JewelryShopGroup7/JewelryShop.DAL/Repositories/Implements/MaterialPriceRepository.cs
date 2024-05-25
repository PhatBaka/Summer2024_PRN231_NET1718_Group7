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
    public class MaterialPriceRepository : IMaterialPriceRepository
    {
        public Task<Guid> AddAsync(MaterialPrice entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<MaterialPrice>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<MaterialPrice>> GetAsync(Expression<Func<MaterialPrice, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<MaterialPrice> GetFirstOrDefaultAsync(Expression<Func<MaterialPrice, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(MaterialPrice entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MaterialPrice entity)
        {
            throw new NotImplementedException();
        }
    }
}
