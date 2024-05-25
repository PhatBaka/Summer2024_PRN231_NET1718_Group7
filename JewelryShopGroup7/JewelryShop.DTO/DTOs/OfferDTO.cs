using System;
using System.Collections.Generic;

namespace JewelryShop.DTO.DTOs;

public partial class OfferDTO
{
    public Guid? OfferId { get; set; }

    public decimal? OfferPercent { get; set; }

    public string? Constraints { get; set; }

    public string? Type { get; set; }

    public Guid? CreatedById { get; set; }

    public Guid? ApprovedById { get; set; }

    //public AccountDTO? ApprovedBy { get; set; }

    //public AccountDTO? CreatedBy { get; set; }

    public List<OrderDiscountDTO> OrderDiscounts { get; } = new List<OrderDiscountDTO>();
}
