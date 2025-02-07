﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs
{
    public partial class JewelryMaterialDTO
    {
        public Guid JewelryId { get; set; }

        public Guid MaterialId { get; set; }

        public decimal Weight { get; set; }

        //public decimal Price { get; set; }

        //public DateTime ImportTime { get; set; }

        //public virtual Jewelry Jewelry { get; set; } = null!;

        public virtual MaterialDTO Material { get; set; } = null!;
    }

    public class CreateJewelryMeterialDTO
    {
        public Guid? MaterialId { get; set; }

        [JsonIgnore]
        public decimal Price { get; set; }

        [JsonIgnore]
        public DateTime ImportTime { get; set; }

        public decimal Weight { get; set; }
    }
}
