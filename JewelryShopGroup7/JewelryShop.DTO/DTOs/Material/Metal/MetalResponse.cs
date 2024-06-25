using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryShop.DTO.DTOs.JewelryMaterial;

namespace JewelryShop.DTO.DTOs.Material.Metal
{
    public class MetalResponse
    {
        public Guid MaterialId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal SellPrice { get; set; }

        public decimal BuyPrice { get; set; }

        public bool IsMetal { get; set; }

        public decimal Weight { get; set; }

        public virtual ICollection<JewelryMaterialResponse> JewelryMaterials { get; set; } = new List<JewelryMaterialResponse>();

        public string? MaterialStatus { get; set; }
    }
}
