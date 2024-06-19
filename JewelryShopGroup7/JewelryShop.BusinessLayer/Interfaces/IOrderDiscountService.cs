using JewelryShop.DTO.DTOs;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IOrderDiscountService : IService<OrderDiscountDTO>
    {
        public Task<Guid> UpdateDiscount(string? tiername ,string? OrderDiscountCode, decimal? offerPercent, decimal? total);
    }
}
