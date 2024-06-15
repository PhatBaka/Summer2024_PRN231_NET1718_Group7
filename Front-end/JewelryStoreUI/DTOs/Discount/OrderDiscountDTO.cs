using System;
using System.Collections.Generic;

namespace JewelryStoreUI.Pages.DTOs.Discount;

public partial class OrderDiscountDTO
{
    public Guid? OrderDiscountId { get; set; }
    public decimal? Value { get; set; }
    public string? Name { get; set; }
    public Guid? StoreDiscountId { get; set; }
    public Guid? OfferId { get; set; }
    public Guid? TierId { get; set; }
    //public OfferDTO? Offer { get; set; }
    //public OrderDTO? Order { get; set; }
    //public TierDTO? Tier { get; set; }
}
