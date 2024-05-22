using System;
using System.Collections.Generic;

namespace JewelryShop.DAL.Models;

public partial class OrderDetail
{
    public Guid OrderDetailId { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? JewelryId { get; set; }

    public decimal? SubTotalPrice { get; set; }

    public virtual ICollection<Guarantee> Guarantees { get; set; } = new List<Guarantee>();

    public virtual Jewelry? Jewelry { get; set; }

    public virtual Order? Order { get; set; }
}
