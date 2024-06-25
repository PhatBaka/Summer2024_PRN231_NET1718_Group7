using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.OrderDiscount
{
    public class OrderDiscountResponse
    {
        public Guid OrderDiscountId { get; set; }

        public string? Type { get; set; }

        public string? Name { get; set; }
        public decimal Value { get; set; }

        public Guid? TierId { get; set; }

        public Guid? StoreDiscountId { get; set; }

        public Guid? OfferId { get; set; }
    }
}
