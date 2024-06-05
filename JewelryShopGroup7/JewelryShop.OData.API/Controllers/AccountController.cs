using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using Microsoft.AspNetCore.OData.Query;

namespace JewelryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAllAsync()
        {
            var result = await _accountService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetByIdAsync(Guid id)
        {
            var result = await _accountService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] AccountDTO createModel)
        {
            var id = await _accountService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] AccountDTO updateModel)
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
