using System.ComponentModel.DataAnnotations;

namespace JewelryShop.DTO.DTOs;

public partial class OrderTypeDTO
{
    [Key]
    public Guid? OrderTypeId { get; set; }

    public string? TypeName { get; set; }

}
