using System.ComponentModel.DataAnnotations;

namespace JewelryShop.DTO.DTOs;

public partial class JewelryTypeDTO
{
    [Key]
    public Guid? TypeId { get; set; }

    public string? TypeName { get; set; }

    // public List<JewelryDTO> Jewelries { get; } = new List<JewelryDTO>();
}
