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
    public class UpdateGemRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal SellPrice { get; set; }

        public required IFormFile MaterialImageFile { get; set; }

        public required IFormFile CertificateImageFile { get; set; }

        public decimal Weight { get; set; }

        public decimal Purity { get; set; }

        public ClarityEnum? Clarity { get; set; }

        public string? Color { get; set; }

        public string? Sharp { get; set; }
    }
}
