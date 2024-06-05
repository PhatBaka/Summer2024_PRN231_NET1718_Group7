using JewelryShop.BusinessLayer.Helpers;
using JewelryShop.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IAccountService : IService<AccountDTO>
    {
        public Task<ResponseResult<AccountDTO>> GetAccountByEmailAndPasswordAsync(LoginDTO loginDTO);
    }
}
