using JewleryShop.MetalPrice.Models;
using System.Collections;

namespace JewleryShop.MetalPrice.Repositories.Interfaces
{
    public interface IMetalRepo
    {
        public Task<IEnumerable<Metal>> GetMetals();
    }
}
