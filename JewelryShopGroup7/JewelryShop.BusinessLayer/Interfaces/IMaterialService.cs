using JewelryShop.DAL.Models;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Material;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IMaterialService : IService<MaterialResponse,CreateMaterialRequest,UpdateMaterialRequest,MaterialFilter>
    {
    }
}
