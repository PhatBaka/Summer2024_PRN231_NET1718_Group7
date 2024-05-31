using System;
using System.Collections.Generic;

namespace JewelryShop.DTO.DTOs;

public partial class JewelryMaterialDTO
{
    public Guid? JewelryId { get; set; }

    public Guid? MaterialId { get; set; }

    public decimal? Weight { get; set; }

    //public JewelryDTO Jewelry { get; set; } = null!;

    //public MaterialDTO Material { get; set; } = null!;
}

public class CreateJewelryMeterialDTO
{
	public Guid? MaterialId { get; set; }

	public decimal? Weight { get; set; }
}
