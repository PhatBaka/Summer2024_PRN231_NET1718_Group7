using JewelryShop.DTO.DTOs.JewelryMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Jewelry
{
    public class CreateJewelryRequest
    {
        public string JewelryName { get; set; }

        public decimal ManufacturingFees { get; set; }

        public string JewelryType { get; set; }

        public string Status { get; set; }

        public string? Barcode { get; set; }

        public decimal GuaranteeDuration { get; set; }

        public Guid ImageId { get; set; }

        public int Quantity { get; set; }

        [JsonIgnore]
        public decimal TotalWeight { get; set; }

        [JsonIgnore]
        public decimal UnitPrice { get; set; }

        [JsonIgnore]
        public decimal SellPrice { get; set; }

        public decimal MarkupPercentage { get; set; }
        public List<CreateJewelryMaterialRequest> CreateJewelryMeterialRequests { get; set; }
    }
}
