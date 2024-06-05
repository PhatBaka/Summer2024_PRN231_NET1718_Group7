namespace JewelryShop.DAL.Models;

public partial class MaterialPrice
{
    public Guid MaterialPriceId { get; set; }

    public Guid? MaterialId { get; set; }

    public DateOnly? Date { get; set; }

    public decimal? Price { get; set; }

    public string UnitType { get; set; }

    public virtual Material? Material { get; set; }
}
