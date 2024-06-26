using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryShop.DTO.DTOs.JewelryMaterial;
using JewelryShop.DTO.DTOs.Jewelry;

namespace JewelryShop.DTO.DTOs.Material.Gem
{
    public class GemResponse
    {
        [Key]
        public Guid MaterialId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal SellPrice { get; set; }

        public decimal BuyPrice { get; set; }

        public bool IsMetal { get; set; }

        public decimal Weight { get; set; }

        public decimal Purity { get; set; }

        public string? Clarity { get; set; }

        public string? Color { get; set; }

        public string? Sharp { get; set; }

        //public virtual ICollection<JewelryMaterialResponse> JewelryMaterials { get; set; } = new List<JewelryMaterialResponse>();

        public byte[]? MaterialImageData { get; set; }

        public byte[]? CertificateImageData { get; set; }

        public ICollection<ShortenJewelryResponse>? Jewelries { get; set; } 
    }
}
