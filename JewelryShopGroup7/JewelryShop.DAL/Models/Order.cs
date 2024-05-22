using System;
using System.Collections.Generic;

namespace JewelryShop.DAL.Models;

public partial class Order
{
    public Guid OrderId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public decimal? DiscountPrice { get; set; }

    public decimal? FinalPrice { get; set; }

    public string? Status { get; set; }

    public Guid? OrderTypeId { get; set; }

    public Guid? OrderDiscountId { get; set; }

    public Guid? AccountId { get; set; }

    public Guid? CustomerId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual OrderDiscount? OrderDiscount { get; set; }

    public virtual OrderType? OrderType { get; set; }
}
