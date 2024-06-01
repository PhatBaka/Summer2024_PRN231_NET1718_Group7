using System;
using System.Collections.Generic;

namespace JewelryShop.DTO.DTOs;

public partial class OrderDetailDTO
{
    public Guid? OrderDetailId { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? JewelryId { get; set; }

    public decimal? SubTotalPrice { get; set; }

	public int Quantity { get; set; }

	public List<GuaranteeDTO> Guarantees { get; } = new List<GuaranteeDTO>();

    //public JewelryDTO? Jewelry { get; set; }

    //public OrderDTO? Order { get; set; }
}

public class CreateOrderDetailDTO 
{
	public Guid? JewelryId { get; set; }
	public int Quantity { get; set; }

	//public decimal? SubTotalPrice { get; set; }
}
