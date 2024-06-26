using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Guarantee;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IGuaranteeService : IService<GuaranteeResponse,CreateGuaranteeRequest,UpdateGuaranteeRequest,GuaranteeFilter>
    {
    }
}
