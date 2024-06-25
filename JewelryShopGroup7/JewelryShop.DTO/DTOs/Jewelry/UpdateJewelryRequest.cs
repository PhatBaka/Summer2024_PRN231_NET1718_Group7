using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Jewelry
{
    public class UpdateJewelryRequest
    {
        public decimal ManufacturingFees { get; set; }

        public Guid JewelryType { get; set; }

        public string Status { get; set; }

        public string Barcode { get; set; }

        public int GuaranteeDuration { get; set; }

    }
}
