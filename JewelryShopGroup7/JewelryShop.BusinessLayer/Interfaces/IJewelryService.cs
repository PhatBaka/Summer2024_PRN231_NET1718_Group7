using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Jewelry;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IJewelryService : IService<JewelryResponse,CreateJewelryRequest,UpdateJewelryRequest,JewelryFilter>
    {
    }
}
