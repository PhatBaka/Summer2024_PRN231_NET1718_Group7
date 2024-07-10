namespace JewelryStoreUI.DTOs.OrderDetails
{
    public class OrderDetailResponse
    {
        public Guid OrderDetailId { get; set; }

        public Guid? OrderId { get; set; }

        public Guid? JewelryId { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal? DiscountPrice { get; set; }

        public decimal FinalPrice { get; set; }

        public decimal DiscountValue { get; set; }

        public int Quantity { get; set; }

        public string? JewelryName { get; set; }

        public byte[]? JewelryImageData { get; set; }
    }
}
