using System;
using System.Collections.Generic;

namespace JewelryShop.DAL.Models;

public partial class Material
{
    public Guid MaterialId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<JewelryMaterial> JewelryMaterials { get; set; } = new List<JewelryMaterial>();

    public virtual ICollection<MaterialPrice> MaterialPrices { get; set; } = new List<MaterialPrice>();
}
