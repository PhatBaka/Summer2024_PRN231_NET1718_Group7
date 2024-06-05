namespace JewelryShop.DAL.Models;

public partial class JewelryMaterial
{
    public Guid JewelryId { get; set; }

    public Guid MaterialId { get; set; }

    public decimal? Weight { get; set; }

    // public decimal Price { get; set; }

    // public DateOnly ImportTime { get; set; }

    public virtual Jewelry Jewelry { get; set; } = null!;

    public virtual Material Material { get; set; } = null!;
}
