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
		[Required(ErrorMessage = "Name is required")]
		public string JewelryName { get; set; }
		[Required(ErrorMessage = "Warranty is required")]
		public int GuaranteeDuration { get; set; }
		[Required(ErrorMessage = "Type is required")]
		public JewelryType JewelryType { get; set; }
		[Required(ErrorMessage = "Quantity is required")]
		public int Quantity { get; set; }
		[Required(ErrorMessage = "Markup percentage is required")]
		public decimal MarkupPercentage { get; set; }
		[Required(ErrorMessage = "Manufacturer Fee is required")]
		public decimal ManufacturerFee { get; set; }
		[Required(ErrorMessage = "Image is required")]
		public IFormFile Image { get; set; }
		public IList<CreateJewelryMeterialDTO> CreateJewelryMeterialDTOs { get; set; }
	}

	public class CreateJewelryMeterialDTO 
	{
        public Guid? MaterialId { get; set; }

        public decimal Weight { get; set; }
    }
}

