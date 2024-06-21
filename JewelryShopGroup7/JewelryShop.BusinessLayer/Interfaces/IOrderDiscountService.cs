using JewelryShop.DTO.DTOs;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IOrderDiscountService : IService<OrderDiscountDTO>
    {
        public Task<Guid> UpdateDiscount(string? tiername ,string? OrderDiscountCode, decimal? offerPercent, decimal? total);
        public Task<decimal?> updateTotalPriceaddOff(decimal offerPercent, decimal? total);
        public Task<decimal?> updateTotalPriceaddStoreCode(string? Code, decimal? total);
        public Task<decimal?> updateTotalPriceaddTier(string? tier, decimal? total);
    }
}
