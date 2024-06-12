using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.OrderDiscount
{
    public class UpdateOrderDiscountRequest
    {
        public string? Type { get; set; }

        public string? Name { get; set; }

        public Guid? TierId { get; set; }

        public Guid? StoreDiscountId { get; set; }

        public Guid? OfferId { get; set; }
    }
}
