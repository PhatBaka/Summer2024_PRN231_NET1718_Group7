using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace JewelryShop.DTO.DTOs;

public partial class JewelryDTO
{
	public Guid JewelryId { get; set; }

	public string JewelryName { get; set; }

	public decimal? ManufacturingFees { get; set; }

	public Guid? JewelryType { get; set; }

	public string? Status { get; set; }

	public string? Barcode { get; set; }

	public decimal? GuaranteeDuration { get; set; }

	public Guid ImageId { get; set; }

	public int Quantity { get; set; }

	public decimal TotalWeight { get; set; }

	public decimal UnitPrice { get; set; }

	public decimal MarkupPercentage { get; set; }

	public string TypeName { get; set; }

	public decimal SellPrice { get; set; }

	public virtual ICollection<JewelryMaterialDTO> JewelryMaterials { get; set; } = new List<JewelryMaterialDTO>();

	public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
}

public partial class CreateJewelryDTO
{
	public string JewelryName { get; set; }

	public decimal? ManufacturingFees { get; set; }

	public Guid? JewelryType { get; set; }

	public string? Status { get; set; }

	public string? Barcode { get; set; }

	public decimal? GuaranteeDuration { get; set; }

	public Guid ImageId { get; set; }

	public int Quantity { get; set; }

	[JsonIgnore]
	public decimal TotalWeight { get; set; }

	[JsonIgnore]
	public decimal UnitPrice { get; set; }

	[JsonIgnore]
	public decimal SellPrice { get; set; }

	public decimal MarkupPercentage { get; set; }

	public List<CreateJewelryMeterialDTO> CreateJewelryMeterialDTOs { get; set; }
}

public class UpdateJewelryDTO
{
	public decimal? ManufacturingFees { get; set; }

	public Guid? JewelryType { get; set; }

	public string? Status { get; set; }

	public string? Barcode { get; set; }

	public int? GuaranteeDuration { get; set; }

	public Guid ImageId { get; set; }
}