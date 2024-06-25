using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Material
{
    public class UpdateMaterialRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string UnitType { get; set; }

        public decimal Price { get; set; }
    }
}
