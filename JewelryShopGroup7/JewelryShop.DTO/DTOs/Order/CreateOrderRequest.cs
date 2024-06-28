using JewelryShop.DTO.DTOs.OrderDetail;
using JewelryShop.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Order
{
    public class CreateOrderRequest
    {
        [JsonIgnore]
        public DateTime? OrderDate { get; set; }

        [JsonIgnore]
        public decimal? TotalPrice { get; set; }

        [JsonIgnore]
        public decimal? DiscountPrice { get; set; }

        [JsonIgnore]
        public decimal? FinalPrice { get; set; }

        [JsonIgnore]
        public OrderStatus Status { get; set; }

        public OrderTypeEnum OrderType { get; set; }

        [JsonIgnore]
        public Guid? OrderDiscountId { get; set; } = null;

        public Guid AccountId { get; set; }

        public string? PhoneNumber { get; set; }

        public List<CreateOrderDetailRequest> OrderDetails { get; set; }
    }
}
