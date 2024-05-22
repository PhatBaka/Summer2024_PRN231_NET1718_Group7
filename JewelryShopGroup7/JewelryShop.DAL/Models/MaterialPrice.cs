using System;
using System.Collections.Generic;

namespace JewelryShop.DAL.Models;

public partial class MaterialPrice
{
    public Guid MaterialPriceId { get; set; }

    public Guid? MaterialId { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Price { get; set; }

    public virtual Material? Material { get; set; }
}
