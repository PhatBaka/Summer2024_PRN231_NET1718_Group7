using System;
using System.Collections.Generic;

namespace JewelryShop.DTO.DTOs;

public partial class MaterialPriceDTO
{
    public Guid? MaterialPriceId { get; set; }

    public Guid? MaterialId { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Price { get; set; }

    //public virtual MaterialDTO? Material { get; set; }
}
