using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryShop.DTO.DTOs.JewelryMaterial;

namespace JewelryShop.DTO.DTOs.Material.Gem
{
    public class GemResponse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MaterialId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        // public string UnitType { get; set; }

        [Column(TypeName = "money")]
        public decimal CurrentPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal SellPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal BuyPrice { get; set; }

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

        public virtual ICollection<JewelryMaterialResponse> JewelryMaterials { get; set; } = new List<JewelryMaterialResponse>();

        // public virtual ICollection<MaterialPrice> MaterialPrices { get; set; } = new List<MaterialPrice>();
    }
}
