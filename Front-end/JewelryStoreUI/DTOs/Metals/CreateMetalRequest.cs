using JewelryStoreUI.Enums;

namespace JewelryStoreUI.DTOs.Metals
{
    public class CreateMetalRequest
    {
        public string? Name { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal Weight { get; set; }

        public MaterialStatus? MaterialStatus { get; set; }
    }
}
