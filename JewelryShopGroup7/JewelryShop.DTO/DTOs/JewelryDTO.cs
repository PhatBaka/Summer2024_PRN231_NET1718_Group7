using System;
using System.Collections.Generic;

namespace JewelryShop.DTO.DTOs;

public partial class JewelryDTO
{
    public Guid? JewelryId { get; set; }

    public decimal? ManufacturingFees { get; set; }

    public Guid? JewelryType { get; set; }

    public string? Status { get; set; }

    public string? Barcode { get; set; }

    public int? GuaranteeDuration { get; set; }

    public List<JewelryMaterialDTO> JewelryMaterials { get; } = new List<JewelryMaterialDTO>();

    public  JewelryTypeDTO? JewelryTypeNavigation { get; set; }

}
