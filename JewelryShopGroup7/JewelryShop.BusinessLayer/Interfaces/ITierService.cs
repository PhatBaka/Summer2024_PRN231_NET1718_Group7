using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Tier;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface ITierService : IService<TierResponse,CreateTierRequest,UpdateTierRequest,TierFilter>
    {
    }
}
