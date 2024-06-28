using JewelryShop.DTO.DTOs.Jewelry;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.OrderDetail
{
    public class OrderDetailResponse
    {
        public Guid OrderDetailId { get; set; }

        public Guid? OrderId { get; set; }

        public Guid? JewelryId { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal? DiscountPrice { get; set; }

        public decimal FinalPrice { get; set; }

        public decimal DiscountValue { get; set; }

        public int Quantity { get; set; }
    }
}
