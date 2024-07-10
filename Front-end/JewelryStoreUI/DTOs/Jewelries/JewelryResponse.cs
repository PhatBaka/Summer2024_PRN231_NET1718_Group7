using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JewelryStoreUI.DTOs.Jewelries
{
    public class JewelryOData : ODataResponseBase<JewelryResponse> 
    { 
    
    }

    public class JewelryResponse 
    {
        [Key]
        public Guid JewelryId { get; set; }

        [Required]
        public string? JewelryName { get; set; }

        public decimal? ManufacturingFees { get; set; }

        public string? JewelryType { get; set; }

        public string? Status { get; set; }

        public decimal? GuaranteeDuration { get; set; }

        public int Quantity { get; set; }

        [Required]
        public decimal TotalWeight { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal MaterialPrice { get; set; }

        [Required]
        public string? JewelryCategory { get; set; }

        public byte[]? JewelryImageData { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalGemPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalMetalPrice { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public ICollection<ShortenMaterialResponse>? Materials { get; set; }
    }
}

public class ShortenJewelryResponse
{
    public Guid JewelryId { get; set; }

    public string? JewelryName { get; set; }

    public decimal? ManufacturingFees { get; set; }

    public string? JewelryType { get; set; }

    public string? Status { get; set; }

    public decimal? GuaranteeDuration { get; set; }

    public int Quantity { get; set; }

    public decimal TotalWeight { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal MaterialPrice { get; set; }

    public string? JewelryCategory { get; set; }

    public byte[]? JewelryImageData { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalGemPrice { get; set; }

    public decimal TotalMetalPrice { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}

public class ShortenMaterialResponse
{
    public Guid MaterialId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public decimal CurrentPrice { get; set; }

    public decimal SellPrice { get; set; }

    public decimal BuyPrice { get; set; }

    public byte[]? MaterialImageData { get; set; }

    public byte[]? CertificateImageData { get; set; }

    public bool IsMetal { get; set; }

    public decimal Weight { get; set; }

    public decimal Purity { get; set; }

    public string? Clarity { get; set; }

    public string? Color { get; set; }

    public string? Sharp { get; set; }

    public string? MaterialStatus { get; set; }
}

