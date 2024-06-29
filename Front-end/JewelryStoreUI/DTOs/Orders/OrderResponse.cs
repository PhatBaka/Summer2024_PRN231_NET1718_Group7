using JewelryStoreUI.DTOs.Accounts;
using JewelryStoreUI.DTOs.Customers;
using JewelryStoreUI.DTOs.OrderDetails;
using System.ComponentModel.DataAnnotations;

namespace JewelryStoreUI.DTOs.Orders
{
    public class OrderOData : ODataResponseBase<OrderResponse> 
    { 
    
    }


    public class OrderResponse
    {
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
