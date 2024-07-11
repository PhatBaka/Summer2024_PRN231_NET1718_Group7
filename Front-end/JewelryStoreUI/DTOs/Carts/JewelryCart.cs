using JewelryStoreUI.Enums;

namespace JewelryStoreUI.DTOs.Carts
{
    public class JewelryCart
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public byte[]? MaterialImageData { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal FinalPrice { get; set; }

        public JewelryType JewelryType { get; set; }
    }
}
