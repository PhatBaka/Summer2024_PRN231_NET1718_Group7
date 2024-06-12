using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.JewelryMaterial
{
    public class CreateJewelryMaterialRequest
    {
        public Guid? MaterialId { get; set; }

        [JsonIgnore]
        public decimal Price { get; set; }

        [JsonIgnore]
        public DateTime ImportTime { get; set; }

        public decimal Weight { get; set; }
        public Guid JewelryId { get; set; }
    }
}
