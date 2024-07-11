using JewelryShop.DAL.Models;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Material;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IMaterialService : IService<MaterialResponse,CreateMaterialRequest,UpdateMaterialRequest,MaterialFilter>
    {
        public Task<MaterialResponse> findAsync(string type);
        Task UpdateMaAsync(Guid id, MaterialResponse updateModel);
        Task<Guid> CreateMaAsync(CreatePriceDTO createModel);
    }
}
