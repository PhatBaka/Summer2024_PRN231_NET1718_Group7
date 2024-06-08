using JewelryShop.DAL.Models;

namespace JewelryShop.DAL.Repositories.Interfaces
{
    public interface IStoreDiscountRepository : IRepositoryBase<StoreDiscount>
    {
        Task<StoreDiscount> LoadRelate(StoreDiscount storeDiscount);
    }
}
