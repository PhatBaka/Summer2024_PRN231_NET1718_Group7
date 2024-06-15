using JewelryShop.DTO.DTOs;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IOrderDiscountService : IService<OrderDiscountDTO>
    {
        public Task<Guid> UpdateDiscount(string? tiername ,string? OrderDiscountCode, decimal? offerPercent, decimal? total);
		public Task<decimal?> UpdateTotalPriceaddOff(decimal offerPercent, decimal? total);
		public Task<decimal?> UpdateTotalPriceaddStoreCode(string? Code, decimal? total);
		public Task<decimal?> UpdateTotalPriceaddTier(string? tier, decimal? total);
	}
}
