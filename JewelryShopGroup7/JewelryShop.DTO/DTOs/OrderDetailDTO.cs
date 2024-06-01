using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JewelryShop.DTO.DTOs;

public partial class OrderDetailDTO
{
    public Guid OrderDetailId { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? JewelryId { get; set; }

    // public decimal? SubTotalPrice { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }


    public decimal? DiscountPrice { get; set; }

    public decimal FinalPrice { get; set; }

    public decimal DiscountValue { get; set; }

    [Required]
    public int Quantity { get; set; }

    public virtual ICollection<GuaranteeDTO> Guarantees { get; set; } = new List<GuaranteeDTO>();

    public virtual JewelryDTO? Jewelry { get; set; }

    // public virtual Order? Order { get; set; }
}

public class CreateOrderDetailDTO 
{
	public Guid? JewelryId { get; set; }
	public int Quantity { get; set; }
    [JsonIgnore]
    public decimal TotalPrice { get; set; }
    [JsonIgnore]
    public decimal? DiscountPrice { get; set; }

    [JsonIgnore]
    public decimal FinalPrice { get; set; }

    [JsonIgnore]
    public decimal UnitPrice { get; set; }

    //public decimal? SubTotalPrice { get; set; }
}
