using System;
using System.Collections.Generic;

namespace JewelryShop.DAL.Models;

public partial class Account
{
    public Guid AccountId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Status { get; set; }

    public Guid? RoleId { get; set; }

    public virtual ICollection<Guarantee> Guarantees { get; set; } = new List<Guarantee>();

    public virtual ICollection<Offer> OfferApprovedBies { get; set; } = new List<Offer>();

    public virtual ICollection<Offer> OfferCreatedBies { get; set; } = new List<Offer>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; }
}
