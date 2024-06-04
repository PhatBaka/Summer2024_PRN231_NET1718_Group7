using JewelryShop.GemPrice.Models;

namespace JewelryShop.GemPrice.Repositories.Interfaces
{
    public interface IMetalRepo
    {
        public Task<IEnumerable<Metal>> GetMetals();
    }
}
