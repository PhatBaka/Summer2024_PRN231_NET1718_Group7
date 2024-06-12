using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.OrderDetail;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IOrderDetailService : IService<OrderDetailResponse,CreateOrderDetailRequest,UpdateOrderDetailRequest,OrderDetailFilter>
    {
    }
}
