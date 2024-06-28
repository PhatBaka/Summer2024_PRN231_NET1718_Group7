using JewelryStoreUI.Enums;
using JewelryStoreUI.Pages.Helpers;
using System.ComponentModel.DataAnnotations;

namespace JewelryStoreUI.Pages.DTOs.Jewelry
{
    public class JewelryDTO : ResponseResult<dynamic>
    {
        public string Base64;
    }

    public class CreateJewelryDTO
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

        public CategoryEnum? JewelryCategory { get; set; }

        [Required]
        public IFormFile? JewelryImageFile { get; set; }

        [Required]
        public IList<Guid>? MaterialIds { get; set; }
    }

    public class CreateJewelryMeterialDTO
    {
        public Guid? MaterialId { get; set; }

        public decimal Weight { get; set; }
    }
}

