using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Order;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IOrderService : IService<OrderResponse,CreateOrderRequest,UpdateOrderRequest,OrderFilter>
    {
    }
}
