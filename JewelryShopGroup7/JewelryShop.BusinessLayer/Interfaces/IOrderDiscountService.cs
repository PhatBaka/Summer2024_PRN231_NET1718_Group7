using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.OrderDiscount;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IOrderDiscountService : IService<OrderDiscountResponse,CreateOrderDiscountRequest,UpdateOrderDiscountRequest,OrderDiscountFilter>
    {
    }
}
