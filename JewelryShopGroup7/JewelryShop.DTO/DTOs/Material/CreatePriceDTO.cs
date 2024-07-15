using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Material
{
    public class CreatePriceDTO
    {
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "money")]
        public decimal CurrentPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal SellPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal BuyPrice { get; set; }
        public bool IsMetal { get; set; }
        public decimal Weight { get; set; }

    }
}
