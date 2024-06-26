namespace JewelryStoreUI.DTOs.Metals
{
    public class MetalResponse
    {
        public Guid MaterialId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal SellPrice { get; set; }

        public decimal BuyPrice { get; set; }

        public bool IsMetal { get; set; }

        public decimal Weight { get; set; }

        public string? MaterialStatus { get; set; }
    }
}
