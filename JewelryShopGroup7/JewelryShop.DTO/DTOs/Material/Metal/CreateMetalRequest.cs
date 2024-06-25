using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelryShop.DTO.DTOs.JewelryMaterial;
using System.Text.Json.Serialization;
using JewelryShop.DTO.Enums;

namespace JewelryShop.DTO.DTOs.Material.Metal
{
    public class CreateMetalRequest
    {
        [Required]
        public string? Name { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate = DateTime.Now;

        public decimal CurrentPrice { get; set; }

        [JsonIgnore]
        public bool IsMetal = true;

        public decimal Weight { get; set; }

        [JsonIgnore]
        public MaterialStatus? MaterialStatus { get; set; }
    }
}
