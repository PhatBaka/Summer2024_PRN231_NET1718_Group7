using JewelryShop.DTO.DTOs.OrderDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.StoreDiscount
{
    public class StoreDiscountResponse
    {
        public Guid? StoreDiscountId { get; set; }

        public string? DiscountCode { get; set; }

        public decimal? DiscountAmount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? RemainingUsage { get; set; }

        public List<OrderDiscountResponse> OrderDiscounts { get; } = new List<OrderDiscountResponse>();
    }
}
