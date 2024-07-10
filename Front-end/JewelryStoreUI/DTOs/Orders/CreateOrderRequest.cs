using JewelryStoreUI.DTOs.OrderDetails;
using JewelryStoreUI.Enums;

namespace JewelryStoreUI.DTOs.Orders
{
    public class CreateOrderRequest
    {
        public Guid AccountId { get; set; }

        public string? PhoneNumber { get; set; }

        public List<CreateOrderDetailRequest> OrderDetails { get; set; }
    }
}
