using JewelryShop.BusinessLayer.Helpers;
using JewelryShop.DTO.DTOs;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IAccountService : IService<AccountDTO>
    {
        public Task<ResponseResult<AccountDTO>> GetAccountByEmailAndPasswordAsync(LoginDTO loginDTO);
    }
}
