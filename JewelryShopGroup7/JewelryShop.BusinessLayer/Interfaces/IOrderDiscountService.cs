﻿using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.OrderDiscount;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IOrderDiscountService : IService<OrderDiscountResponse,CreateOrderDiscountRequest,UpdateOrderDiscountRequest,OrderDiscountFilter>
    {
        public Task<Guid> UpdateDiscount(string? tiername ,string? OrderDiscountCode, decimal? offerPercent, decimal? total);
        Task<decimal?> updateTotalPriceaddOff(decimal offerPercent, decimal? total);
        Task<decimal?> updateTotalPriceaddStoreCode(string? Code, decimal? total);
        Task<decimal?> updateTotalPriceaddTier(string? tier, decimal? total);
    }
}
