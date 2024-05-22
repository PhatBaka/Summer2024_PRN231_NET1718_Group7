using System;
using System.Collections.Generic;

namespace JewelryShop.DAL.Models;

public partial class OrderDiscount
{
    public Guid OrderDiscountId { get; set; }

    public string? Type { get; set; }

    public string? Name { get; set; }

    public Guid? TierId { get; set; }

    public Guid? StoreDiscountId { get; set; }

    public Guid? OfferId { get; set; }

    public virtual Offer? Offer { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual StoreDiscount? StoreDiscount { get; set; }

    public virtual Tier? Tier { get; set; }
}
