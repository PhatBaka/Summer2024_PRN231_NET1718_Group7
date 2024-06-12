using JewelryShop.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Order
{
    public class UpdateOrderRequest
    {
        public DateTime? OrderDate { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? DiscountPrice { get; set; }

        public decimal? FinalPrice { get; set; }

        public OrderStatus? Status { get; set; }

        public Guid? OrderDiscountId { get; set; }

        public OrderTypeEnum OrderType { get; set; }

        public Guid? AccountId { get; set; }

        public Guid? CustomerId { get; set; }
    }
}
