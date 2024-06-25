using JewelryShop.DTO.DTOs;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IGuaranteeService : IService<GuaranteeDTO>
    {
        public Task CreateofOrderAsync(GuaranteeDTO createModel, Guid id);
    }
}
