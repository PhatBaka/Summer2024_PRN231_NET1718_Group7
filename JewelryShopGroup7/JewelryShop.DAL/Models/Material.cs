namespace JewelryShop.DAL.Models;

public partial class Material
{
    public Guid MaterialId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? Date { get; set; }

    public string UnitType { get; set; }

    public decimal Price { get; set; }

    public Guid ImageId { get; set; }

    public virtual Image Image { get; set; }

    public Guid CertificateId { get; set; }

    public bool IsMetal { get; set; }

    public virtual ICollection<JewelryMaterial> JewelryMaterials { get; set; } = new List<JewelryMaterial>();

    public virtual ICollection<MaterialPrice> MaterialPrices { get; set; } = new List<MaterialPrice>();
}
