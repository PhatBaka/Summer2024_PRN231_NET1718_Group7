﻿using JewelryStoreUI.Pages.Helpers;

namespace JewelryStoreUI.Pages.DTOs.OrderDetail
{
    public class OrderDetailDTO : ResponseResult<dynamic>
    {
        public string Base64;
    }

    public class CreateOrderDetailDTO
    {
        public Guid JewelryId { get; set; }
        public int Quantity { get; set; }
    }
}
