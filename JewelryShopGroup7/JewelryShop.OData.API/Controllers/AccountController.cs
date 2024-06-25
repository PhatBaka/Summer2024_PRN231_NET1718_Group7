using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/AccountOData")]
    [ApiController]
    public class AccountController : ODataController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<AccountResponse>>> GetAllAsync()
        {
            var result = await _accountService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountResponse>> GetByIdAsync(Guid id)
        {
            var result = await _accountService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateAccountRequest createModel)
        {
            var id = await _accountService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateAccountRequest updateModel)
        {
            try
            {
                await _accountService.UpdateAsync(id, updateModel);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _accountService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
