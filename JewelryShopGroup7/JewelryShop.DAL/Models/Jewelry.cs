﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JewelryShop.DAL.Models;

public partial class Jewelry
{
    public Guid JewelryId { get; set; }

    public decimal? ManufacturingFees { get; set; }

    public Guid? JewelryType { get; set; }

    public string? Status { get; set; }

    public string? Barcode { get; set; }

    public int? GuaranteeDuration { get; set; }

	public virtual JewelryType? JewelryTypeNavigation { get; set; }

	public Guid ImageId { get; set; }

	public virtual Image Image { get; set; }

	public virtual ICollection<JewelryMaterial> JewelryMaterials { get; set; } = new List<JewelryMaterial>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}