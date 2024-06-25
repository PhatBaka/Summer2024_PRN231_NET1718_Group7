using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Material
{
    public class MaterialResponse
    {
        public Guid? MaterialId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateOnly? Date { get; set; }

        public string? UnitType { get; set; }

        public decimal Price { get; set; }

        public Guid? ImageId { get; set; }
    }
}
