using JewelryStoreUI.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace JewelryStoreUI.DTOs.Gems
{
    public class CreateGemRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? SellPrice { get; set; }
        public IFormFile? MaterialImageFile { get; set; }
        public IFormFile? CertificateImageFile { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Purity { get; set; }
        public ClarityEnum? Clarity { get; set; }
        public string? Color { get; set; }
        public string? Sharp { get; set; }
    }
}
