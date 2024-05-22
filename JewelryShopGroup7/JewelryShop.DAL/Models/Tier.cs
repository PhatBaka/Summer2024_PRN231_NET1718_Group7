using System;
using System.Collections.Generic;

namespace JewelryShop.DAL.Models;

public partial class Tier
{
    public Guid TierId { get; set; }

    public string TierName { get; set; } = null!;

    public decimal MinAmountSpent { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public virtual ICollection<OrderDiscount> OrderDiscounts { get; set; } = new List<OrderDiscount>();
}
