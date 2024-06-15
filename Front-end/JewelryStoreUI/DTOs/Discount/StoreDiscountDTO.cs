using System;
using System.Collections.Generic;

namespace JewelryStoreUI.Pages.DTOs.Discount;

public partial class StoreDiscountDTO
{
    public Guid? StoreDiscountId { get; set; }

    public string? DiscountCode { get; set; }

    public decimal? DiscountAmount { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? RemainingUsage { get; set; }

    public List<OrderDiscountDTO> OrderDiscounts { get; } = new List<OrderDiscountDTO>();
}
