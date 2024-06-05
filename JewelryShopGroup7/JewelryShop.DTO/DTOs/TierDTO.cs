namespace JewelryShop.DTO.DTOs
{
    public class TierDTO
    {
        public Guid? TierId { get; set; }

        public string? TierName { get; set; } = null!;

        public decimal? MinAmountSpent { get; set; }

        public decimal? DiscountPercentage { get; set; }

    }
}
