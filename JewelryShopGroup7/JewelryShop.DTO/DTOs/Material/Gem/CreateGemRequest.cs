using JewelryShop.DTO.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Material.Gem
{
    public class CreateGemRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate = DateTime.Now;

        // giá tiền của kim cương được fix cứng từ đầu 
        // giá bán
        public decimal SellPrice { get; set; }

        public required IFormFile MaterialImageFile { get; set; }

        public required IFormFile CertificateImageFile { get; set; }

        public bool IsMetal = false;

        public decimal Weight { get; set; }

        public decimal Purity { get; set; }

        public ClarityEnum? Clarity { get; set; }

        public string? Color { get; set; }

        public string? Sharp { get; set; }

        [JsonIgnore]
        public MaterialStatus? MaterialStatus { get; set; }
    }
}
