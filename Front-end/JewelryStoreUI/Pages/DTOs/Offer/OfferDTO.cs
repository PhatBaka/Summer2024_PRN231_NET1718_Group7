namespace JewelryStoreUI.Pages.DTOs.Offter
{
    public class OfferDTO
    {
        public Guid OfferId { get; set; }

        public decimal? OfferPercent { get; set; }

        public string? Constraints { get; set; }

        public Guid? CreatedById { get; set; }

        public Guid? ApprovedById { get; set; }

        public virtual ICollection<OrderDiscountDTO> OrderDiscounts { get; set; } = new List<OrderDiscountDTO>();
    }
}
