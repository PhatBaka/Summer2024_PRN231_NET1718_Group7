using System.ComponentModel.DataAnnotations;

namespace JewelryShop.DTO.DTOs
{
    public class TierResponse
    {
        [Key]
        public Guid? TierId { get; set; }

        public string? TierName { get; set; } = null!;

        public decimal? MinAmountSpent { get; set; }

        public decimal? DiscountPercentage { get; set; }

    }
}
