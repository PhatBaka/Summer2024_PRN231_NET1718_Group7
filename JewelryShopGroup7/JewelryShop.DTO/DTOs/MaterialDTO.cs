using System;
using System.Collections.Generic;

namespace JewelryShop.DTO.DTOs;

public partial class MaterialDTO
{
    public Guid? MaterialId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
	public Guid ImageId { get; set; }

	public List<JewelryMaterialDTO> JewelryMaterials { get; } = new List<JewelryMaterialDTO>();

    public List<MaterialPriceDTO> MaterialPrices { get; } = new List<MaterialPriceDTO>();
}
