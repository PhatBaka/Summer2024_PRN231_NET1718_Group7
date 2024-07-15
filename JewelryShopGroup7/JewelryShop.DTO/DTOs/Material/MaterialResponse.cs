using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryShop.DTO.DTOs.Jewelry;

namespace JewelryShop.DTO.DTOs.Material
{
    public class MaterialResponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MaterialId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        // public string UnitType { get; set; }

        [Column(TypeName = "money")]
        public decimal CurrentPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal SellPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal BuyPrice { get; set; }

        //public Guid ImageId { get; set; }
        //public virtual Image Image { get; set; }

        //public Guid MaterialImageId { get; set; }

        //public Guid CertificateImageId { get; set; }

        public byte[]? MaterialImageData { get; set; }

        public byte[]? CertificateImageData { get; set; }

        public bool IsMetal { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Weight { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Purity { get; set; }

        public string? Clarity { get; set; }

        public string? Color { get; set; }

        public string? Sharp { get; set; }

        public virtual ICollection<JewelryMaterialResponse>? Jewelries { get; set; } = new List<JewelryMaterialResponse>();

        public string? MaterialStatus { get; set; }
    }

    public class JewelryMaterialResponse 
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

        public decimal TotalGemPrice { get; set; }

        public decimal TotalMetalPrice { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
