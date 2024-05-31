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

	public decimal? ManufacturingFees { get; set; }

	public string JewelryName { get; set; }

	public Guid? JewelryType { get; set; }

	public string? Status { get; set; }

	public string? Barcode { get; set; }

	public int? GuaranteeDuration { get; set; }

	public string? TypeName { get; set; }

	// public virtual JewelryType? JewelryTypeNavigation { get; set; }

	public Guid ImageId { get; set; }

	//public virtual ImageDTO Image { get; set; }

	// public byte[] ImageData { get; set; }

	public virtual ICollection<JewelryMaterialDTO> JewelryMaterials { get; set; } = new List<JewelryMaterialDTO>();

	public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
}

public partial class CreateJewelryDTO
{
	public decimal? ManufacturingFees { get; set; }

	public Guid? JewelryType { get; set; }

	[JsonIgnore]
	public string? Status { get; set; }

	public string? Barcode { get; set; }

	public int? GuaranteeDuration { get; set; }

	public Guid ImageId { get; set; }

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