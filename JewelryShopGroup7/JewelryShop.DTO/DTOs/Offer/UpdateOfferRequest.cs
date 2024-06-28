﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Offer
{
    public class UpdateOfferRequest
    {
        public decimal? OfferPercent { get; set; }

        public string? Constraints { get; set; }
    }
}