using JewelryStoreUI.Enums;
using JewelryStoreUI.Pages.DTOs.OrderDetail;
using JewelryStoreUI.Pages.Helpers;

namespace JewelryStoreUI.Pages.DTOs.Order
{
    public class OrderDTO : ResponseResult<dynamic>
    {

    }

    public class CreateOrderDTO
    {
        public OrderStatus Status { get; set; }
        public OrderType OrderType { get; set; }
        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public Guid OrderDiscountId { get; set; }
        public IList<CreateOrderDetailDTO> CreateOrderDetailDTOs { get; set; }
    }
}
