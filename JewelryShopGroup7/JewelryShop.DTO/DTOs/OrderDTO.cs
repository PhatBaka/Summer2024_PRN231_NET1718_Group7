﻿using JewelryShop.DTO.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JewelryShop.DTO.DTOs;

public partial class OrderDTO
{
    [Key]
    public Guid? OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public decimal? DiscountPrice { get; set; }

    public decimal? FinalPrice { get; set; }

    public OrderStatus? Status { get; set; }

    public Guid? OrderDiscountId { get; set; }

    public OrderTypeEnum OrderType { get; set; }

    public Guid? AccountId { get; set; }

    public Guid? CustomerId { get; set; }

    public string? PhoneNumber { get; set; }

    //public AccountDTO? Account { get; set; }

    //public CustomerDTO? Customer { get; set; }

    public List<OrderDetailDTO> OrderDetails { get; } = new List<OrderDetailDTO>();

    //public OrderDiscountDTO? OrderDiscount { get; set; }

    //public OrderTypeDTO? OrderType { get; set; }
}

public class CreateOrderDTO
{
    [JsonIgnore]
    public DateTime? OrderDate { get; set; }

    [JsonIgnore]
    public decimal? TotalPrice { get; set; }

    [JsonIgnore]
    public decimal? DiscountPrice { get; set; }

    [JsonIgnore]
    public decimal? FinalPrice { get; set; }

    public OrderStatus Status { get; set; }

    public OrderTypeEnum OrderType { get; set; }

    public Guid? OrderDiscountId { get; set; } = null;

    public Guid AccountId { get; set; }

    public Guid? CustomerId { get; set; }

    public List<CreateOrderDetailDTO> OrderDetails { get; set; }
}

public class UpdateOrderDTO 
{
    [JsonIgnore]
    public DateTime? OrderDate { get; set; }

    [JsonIgnore]
    public decimal? TotalPrice { get; set; }

    [JsonIgnore]
    public decimal? DiscountPrice { get; set; }

    [JsonIgnore]
    public decimal? FinalPrice { get; set; }

    public OrderStatus Status { get; set; }

    public OrderTypeEnum OrderType { get; set; }

    public Guid? OrderDiscountId { get; set; } = null;

    public Guid AccountId { get; set; }

    public Guid? CustomerId { get; set; }

    public List<CreateOrderDetailDTO> OrderDetails { get; set; }
}
