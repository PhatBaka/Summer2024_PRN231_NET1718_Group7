using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.OrderDetail
{
    public class CreateOrderDetailRequest
    {
        public Guid JewelryId { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public decimal TotalPrice { get; set; }
        [JsonIgnore]
        public decimal? DiscountPrice { get; set; }

        [JsonIgnore]
        public decimal FinalPrice { get; set; }

        [JsonIgnore]
        public decimal UnitPrice { get; set; }

        //public decimal? SubTotalPrice { get; set; }
    }
}
