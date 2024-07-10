namespace JewelryStoreUI.DTOs.OrderDetails
{
    public class CreateOrderDetailRequest
    {
        public Guid JewelryId { get; set; }
        public int Quantity { get; set; }
    }
}
