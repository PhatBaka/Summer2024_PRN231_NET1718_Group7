using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Jewelry
{
    public class JewelryFilter
    {

        public string JewelryName { get; set; }

        public decimal? ManufacturingFees { get; set; }

        public string JewelryType { get; set; }

        public string? Status { get; set; }

        public string? Barcode { get; set; }

        public decimal? GuaranteeDuration { get; set; }

        public Guid ImageId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalWeight { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal MarkupPercentage { get; set; }

        public decimal SellPrice { get; set; }
    }
}
