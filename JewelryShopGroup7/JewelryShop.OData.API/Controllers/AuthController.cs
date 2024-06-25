using JewelryShop.BusinessLayer.Helpers;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Account;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<ResponseResult<AccountResponse>> Login([FromBody] LoginRequest loginDTO)
        {
            return _accountService.GetAccountByEmailAndPasswordAsync(loginDTO).Result;
        }
    }
}
