using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Offer;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IOfferService : IService<OfferResponse,CreateOfferRequest,UpdateOfferRequest,OfferFilter>
    {
    }
}
