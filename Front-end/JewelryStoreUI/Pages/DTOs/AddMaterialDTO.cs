using System.ComponentModel.DataAnnotations;

namespace JewelryStoreUI.Pages.DTOs
{
    public class AddMaterialDTO
    {
        [Required(ErrorMessage = "Material Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Material Description is required")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Material Image is required")]
        public IFormFile ImageData { get; set; }
        public List<MaterialPriceDTO> MaterialPrices { get; } = new List<MaterialPriceDTO>();
    }
}
