using JewelryShop.DTO.DTOs.JewelryMaterial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Material.Metal
{
    public class UpdateMetalRequest
    {
        [Required]
        public string? Name { get; set; }

        public DateTime? CreatedDate { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal SellPrice { get; set; }

        public decimal BuyPrice { get; set; }

        public bool IsMetal { get; set; }

        public decimal Weight { get; set; }

        public string? MaterialStatus { get; set; }
    }
}
