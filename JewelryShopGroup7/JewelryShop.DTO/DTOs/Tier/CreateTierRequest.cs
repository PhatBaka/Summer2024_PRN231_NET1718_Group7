using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Tier
{
    public class CreateTierRequest
    {
        public string? TierName { get; set; } = null!;

        public decimal? MinAmountSpent { get; set; }

        public decimal? DiscountPercentage { get; set; }
    }
}
