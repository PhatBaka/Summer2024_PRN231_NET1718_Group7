namespace JewelryStoreUI.DTOs.Carts
{
    public class MaterialCart
    {
        public Guid MaterialId { get; set; }
        public string? Name { get; set; }
        public byte[]? MaterialImageData { get; set; }
        public bool? IsMetal { get; set; }
        public decimal Weight { get; set; }
        public decimal SellPrice { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
