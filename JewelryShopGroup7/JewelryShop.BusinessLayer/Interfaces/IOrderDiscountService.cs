using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.OrderDiscount;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IOrderDiscountService : IService<OrderDiscountResponse,CreateOrderDiscountRequest,UpdateOrderDiscountRequest,OrderDiscountFilter>
    {
        public Task<Guid> UpdateDiscount(string? tiername ,string? OrderDiscountCode, decimal? offerPercent, decimal? total);
		public Task<decimal?> UpdateTotalPriceaddOff(decimal offerPercent, decimal? total);
		public Task<decimal?> UpdateTotalPriceaddStoreCode(string? Code, decimal? total);
		public Task<decimal?> UpdateTotalPriceaddTier(string? tier, decimal? total);
	}
}
