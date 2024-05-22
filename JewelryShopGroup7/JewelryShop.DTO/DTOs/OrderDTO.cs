using System;
using System.Collections.Generic;

namespace JewelryShop.DTO.DTOs;

public partial class OrderDTO
{
    public Guid? OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public decimal? DiscountPrice { get; set; }

    public decimal? FinalPrice { get; set; }

    public string? Status { get; set; }

    public Guid? OrderTypeId { get; set; }

    public Guid? OrderDiscountId { get; set; }

    public Guid? AccountId { get; set; }

    public Guid? CustomerId { get; set; }

    public AccountDTO? Account { get; set; }

    public CustomerDTO? Customer { get; set; }

    public  List<OrderDetailDTO> OrderDetails { get; } = new List<OrderDetailDTO>();

    public OrderDiscountDTO? OrderDiscount { get; set; }

    public OrderTypeDTO? OrderType { get; set; }
}
