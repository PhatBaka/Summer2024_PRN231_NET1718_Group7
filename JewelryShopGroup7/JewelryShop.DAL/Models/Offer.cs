using System;
using System.Collections.Generic;

namespace JewelryShop.DAL.Models;

public partial class Offer
{
    public Guid OfferId { get; set; }

    public decimal? OfferPercent { get; set; }

    public string? Constraints { get; set; }

    public Guid? CreatedById { get; set; }

    public Guid? ApprovedById { get; set; }

    public virtual Account? ApprovedBy { get; set; }

    public virtual Account? CreatedBy { get; set; }

    public virtual ICollection<OrderDiscount> OrderDiscounts { get; set; } = new List<OrderDiscount>();
}
