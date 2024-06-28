using JewelryShop.DTO.DTOs.JewelryMaterial;
using JewelryShop.DTO.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Jewelry
{
    public class CreateJewelryRequest
    {
        [Required]
        public Guid JewelryId { get; set; }

        [Required]
        public string? JewelryName { get; set; }

        [Required]
        public decimal ManufacturingFees { get; set; }

        [Required]
        public JewelryType? JewelryType { get; set; }

        //public ObjectStatus? Status { get; set; }

        //public string? Barcode { get; set; }

        public decimal? GuaranteeDuration { get; set; }

        //public Guid ImageId { get; set; }

        public int? Quantity { get; set; }

        //[JsonIgnore]
        //public decimal TotalWeight { get; set; }

        //[JsonIgnore]
        //public decimal? UnitPrice { get; set; }

        //[JsonIgnore]
        //public decimal MaterialPrice { get; set; }

        //[JsonIgnore]
        //public decimal TotalGemPrice { get; set; }

        //[JsonIgnore]
        //public decimal TotalMetalPrice { get; set; }

        //[JsonIgnore]
        //public DateTime? CreatedDate = DateTime.Now;

        public CategoryEnum? JewelryCategory { get; set; }

        [Required]
        public IFormFile? JewelryImageFile { get; set; }

        //[JsonIgnore]
        //public decimal SellPrice { get; set; }

        [Required]
        //public decimal MarkupPercentage { get; set; }
        public IList<Guid>? MaterialIds { get; set; }
    }
}
