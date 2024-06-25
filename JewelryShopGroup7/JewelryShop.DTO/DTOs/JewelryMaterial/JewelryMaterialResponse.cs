using JewelryShop.DTO.DTOs.Jewelry;
using JewelryShop.DTO.DTOs.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.JewelryMaterial
{
    public class JewelryMaterialResponse
    {
        public Guid JewelryId { get; set; }

        public Guid MaterialId { get; set; }

        public decimal? Weight { get; set; }
        //public JewelryResponse Jewelry { get; set; } = null!;

        //public MaterialResponse Material { get; set; } = null!;
    }
}
