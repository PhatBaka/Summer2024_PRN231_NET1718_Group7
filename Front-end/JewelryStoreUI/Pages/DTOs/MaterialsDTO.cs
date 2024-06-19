namespace JewelryStoreUI.Pages.DTOs
{
	public class MaterialsDTO
	{
		public string? Name { get; set; }

		public string? Description { get; set; }
		public List<MaterialPriceDTO> MaterialPrices { get; } = new List<MaterialPriceDTO>();
	}
}
