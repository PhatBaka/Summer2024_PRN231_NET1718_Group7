using JewelryStoreUI.Enums;
using System.ComponentModel.DataAnnotations;

namespace JewelryStoreUI.DTOs.Jewelries
{
    public class CreateJewelryRequest
    {
        [Required]
        public Guid JewelryId { get; set; }

        [Required]
        public string? JewelryName { get; set; }

        [Required]
        public decimal ManufacturingFees { get; set; }

        [Required]
        public JewelryType? JewelryType { get; set; }

        public decimal? GuaranteeDuration { get; set; }

        public int? Quantity { get; set; }

        public JewelryCategory? JewelryCategory { get; set; }

        [Required]
        public IFormFile? JewelryImageFile { get; set; }

        [Required]
        public IList<Guid>? MaterialIds { get; set; }
    }
}
