using JewelryShop.BusinessLayer.BackgroundServices;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Order;
using JewelryShop.DTO.DTOs.OrderDiscount;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IOrderDiscountService : IService<OrderDiscountResponse,CreateOrderDiscountRequest,UpdateOrderDiscountRequest,OrderDiscountFilter>
    {
        public Task<Guid> UpdateDiscount(string? tiername ,string? OrderDiscountCode, decimal? offerPercent, decimal? total);
        public Task<decimal?> updateTotalPriceaddOff(decimal offerDis, decimal? total);
        public Task<decimal?> updateTotalPriceaddStoreCode(string storeCode, decimal? total);
        public Task<decimal?> updateTotalPriceaddTier(string Tiername, decimal? total);
    }
}
