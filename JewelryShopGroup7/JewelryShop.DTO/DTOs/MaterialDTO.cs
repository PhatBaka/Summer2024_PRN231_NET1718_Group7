using System;
using System.Collections.Generic;

namespace JewelryShop.DTO.DTOs;

public partial class MaterialDTO
{
	public Guid MaterialId { get; set; }

	public string? Name { get; set; }

	public string? Description { get; set; }

	public DateTime? Date { get; set; }

	public string UnitType { get; set; }

	public decimal Price { get; set; }

	public Guid ImageId { get; set; }

	public virtual ImageDTO Image { get; set; }

	public virtual ICollection<JewelryMaterialDTO> JewelryMaterials { get; set; } = new List<JewelryMaterialDTO>();

	// public virtual ICollection<MaterialPriceDTO> MaterialPrices { get; set; } = new List<MaterialPrice>();
}
