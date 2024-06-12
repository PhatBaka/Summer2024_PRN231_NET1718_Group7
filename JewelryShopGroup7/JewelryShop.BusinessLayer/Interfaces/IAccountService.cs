using JewelryShop.BusinessLayer.Helpers;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Account;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IAccountService : IService<AccountResponse,CreateAccountRequest,UpdateAccountRequest,AccountFilter>
    {
        public Task<ResponseResult<AccountResponse>> GetAccountByEmailAndPasswordAsync(LoginRequest loginDTO);
    }
}
