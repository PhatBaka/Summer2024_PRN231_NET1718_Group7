using JewelryShop.DTO.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JewelryShop.DTO.DTOs;

public partial class MaterialDTO
{
    [Key]
    public Guid? MaterialId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

	//public DateOnly? Date { get; set; }

    //public string? UnitType { get; set; }

    //public decimal Price { get; set; }

    //public Guid? ImageId { get; set; }

	// public virtual ImageDTO Image { get; set; }

    // public ICollection<JewelryMaterialDTO> JewelryMaterials { get; set; } = new List<JewelryMaterialDTO>();

    // public virtual ICollection<MaterialPriceDTO> MaterialPrices { get; set; } = new List<MaterialPrice>();

    public DateTime? CreatedDate { get; set; }

    public decimal CurrentPrice { get; set; }

    public decimal SellPrice { get; set; }

    public decimal BuyPrice { get; set; }

    public byte[]? MaterialImageData { get; set; }

    public byte[]? CertificateImageData { get; set; }

    public decimal Weight { get; set; }

    public decimal Purity { get; set; }

    public ClarityEnum? Clarity { get; set; }

    public string? Color { get; set; }

    public string? Sharp { get; set; }

    public bool IsMetal { get; set; }
}

public class GemDTO
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    [JsonIgnore]
    public DateTime? CreatedDate = DateTime.Now;

    // giá tiền của kim cương được fix cứng từ đầu 
    // giá bán
    public decimal SellPrice { get; set; }

    // giá mua: 70% giá bán 
    [JsonIgnore]
    public decimal BuyPrice { get; set; }

    public required IFormFile MaterialImageFile { get; set; }

    public required IFormFile CertificateImageFile { get; set; }

    public bool IsMetal = false;

    public decimal Weight { get; set; }

    public decimal Purity { get; set; }

    public ClarityEnum? Clarity { get; set; }

    public string? Color { get; set; }

    public string? Sharp { get; set; }
}

public class MetalDTO 
{
    [Required]
    public string? Name { get; set; }

    [JsonIgnore]
    public DateTime? CreatedDate = DateTime.Now;

    public decimal Weight { get; set; }

    public decimal CurrentPrice { get; set; }

    public decimal SellPrice { get; set; }

    public decimal BuyPrice { get; set; }

    public bool IsMetal = true;
}
