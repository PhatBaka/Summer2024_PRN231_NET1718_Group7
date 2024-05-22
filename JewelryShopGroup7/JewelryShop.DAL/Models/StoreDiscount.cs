using System;
using System.Collections.Generic;

namespace JewelryShop.DAL.Models;

public partial class StoreDiscount
{
    public Guid StoreDiscountId { get; set; }

    public string? DiscountCode { get; set; }

    public decimal? DiscountAmount { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? RemainingUsage { get; set; }

    public virtual ICollection<OrderDiscount> OrderDiscounts { get; set; } = new List<OrderDiscount>();
}
