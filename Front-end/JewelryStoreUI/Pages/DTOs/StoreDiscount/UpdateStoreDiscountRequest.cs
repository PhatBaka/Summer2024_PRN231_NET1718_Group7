namespace JewelryStoreUI.Pages.DTOs.StoreDiscount
{
    public class UpdateStoreDiscountRequest
    {
        public string? DiscountCode { get; set; }

        public decimal? DiscountAmount { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? RemainingUsage { get; set; }
    }
}
