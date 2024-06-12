using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.StoreDiscount;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IStoreDiscountService : IService<StoreDiscountResponse,CreateStoreDiscountRequest,UpdateStoreDiscountRequest,StoreDiscountFilter>
    {
    }
}
