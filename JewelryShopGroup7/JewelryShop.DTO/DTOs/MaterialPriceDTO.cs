using System.ComponentModel.DataAnnotations;

namespace JewelryShop.DTO.DTOs;

public partial class MaterialPriceDTO
{
    [Key]
    public Guid? MaterialPriceId { get; set; }

    public Guid? MaterialId { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Price { get; set; }

    //public virtual MaterialDTO? Material { get; set; }
}
