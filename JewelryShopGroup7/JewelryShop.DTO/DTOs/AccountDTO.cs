using System;
using System.Collections.Generic;

namespace JewelryShop.DTO.DTOs;

public partial class AccountDTO
{
    public Guid? AccountId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Status { get; set; }

    public Guid? RoleId { get; set; }

    public List<GuaranteeDTO> Guarantees { get; } = new List<GuaranteeDTO>();

    public List<OfferDTO> OfferApprovedBies { get; } = new List<OfferDTO>();

    public List<OfferDTO> OfferCreatedBies { get; } = new List<OfferDTO>();

    public List<OrderDTO> Orders { get; } = new List<OrderDTO>();

    public virtual RoleDTO? Role { get; set; }
}
