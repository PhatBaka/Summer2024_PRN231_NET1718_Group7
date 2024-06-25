using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Customer;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface ICustomerService : IService<CustomerResponse,CreateCustomerRequest,UpdateCustomerRequest,CustomerFilter>
    {
    }
}
