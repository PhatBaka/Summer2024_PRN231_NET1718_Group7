﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.JewelryMaterial
{
    public class UpdateJewelryMaterialRequest
    {

        public Guid MaterialId { get; set; }

        public decimal? Weight { get; set; }

    }
}
