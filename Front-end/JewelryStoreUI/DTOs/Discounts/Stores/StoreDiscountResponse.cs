using JewelryStoreUI.DTOs.Discounts.Orders;

namespace JewelryStoreUI.DTOs.Promotions.Stores
{
    public class StoreDiscountOData  : ODataResponseBase<StoreDiscountResponse>
    {
    }

    public class StoreDiscountResponse
    {
        public Guid? StoreDiscountId { get; set; }

        public string? DiscountCode { get; set; }

        public decimal? DiscountAmount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? RemainingUsage { get; set; }

        public List<OrderDiscountResponse> OrderDiscounts { get; } = new List<OrderDiscountResponse>();
    }
}
