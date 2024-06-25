using JewelryStoreUI.Pages.DTOs.Jewelry;

namespace JewelryStoreUI.Pages.DTOs.Cart
{
    public class Cart : JewelryDTO
    {
        public Guid JewelryId { get; set; }
        public int Quantity { get; set; }
    }
}
