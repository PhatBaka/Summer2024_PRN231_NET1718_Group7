using JewelryShop.DTO.DTOs.Account;
using JewelryShop.DTO.DTOs.Customer;
using JewelryShop.DTO.DTOs.OrderDetail;
using JewelryShop.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Order
{
    public class OrderResponse
    {
        [Key]
        public Guid OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? DiscountPrice { get; set; }

        public decimal? FinalPrice { get; set; }

        public string? Status { get; set; }

        //public Guid? OrderTypeId { get; set; }

        public string OrderType { get; set; }

        public Guid? OrderDiscountId { get; set; }

        public Guid? AccountId { get; set; }

        public Guid? CustomerId { get; set; }

        public virtual AccountResponse? Account { get; set; }

        public virtual CustomerResponse? Customer { get; set; }

        public virtual ICollection<OrderDetailResponse> OrderDetails { get; set; } = new List<OrderDetailResponse>();

        //public virtual OrderDiscount? OrderDiscount { get; set; }
    }
}
