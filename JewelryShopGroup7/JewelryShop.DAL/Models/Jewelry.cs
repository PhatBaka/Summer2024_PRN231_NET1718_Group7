using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryShop.DAL.Models;

public partial class Jewelry
{
    public Guid JewelryId { get; set; }

    [Required]
    public string? JewelryName { get; set; }

    [Column(TypeName = "money")]
    public decimal? ManufacturingFees { get; set; }

    public string? JewelryType { get; set; }

    public string? Status { get; set; }

    //public string? Barcode { get; set; }

    public decimal? GuaranteeDuration { get; set; }

    // public virtual JewelryType? JewelryTypeNavigation { get; set; }

    //public Guid ImageId { get; set; }

    public int Quantity { get; set; }

    [Required]
    public decimal TotalWeight { get; set; }

    [Required]
    [Column(TypeName = "money")]
    public decimal UnitPrice { get; set; }

    [Required]
    [Column(TypeName = "money")]
    public decimal MaterialPrice { get; set; }

    //[Required]
    //public double MarkupPercentage { get; set; }

    //public virtual Image Image { get; set; }

    [Required]
    public string? JewelryCategory { get; set; }

    public byte[]? JewelryImageData { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalGemPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalMetalPrice { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    //public virtual ICollection<JewelryMaterial> JewelryMaterials { get; set; } = new List<JewelryMaterial>();

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

}
