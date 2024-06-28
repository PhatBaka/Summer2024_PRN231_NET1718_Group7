using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs.Account;
using JewelryShop.DTO.DTOs.Material.Gem;
using JewelryShop.DTO.Enums;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GemController : Controller
    {
        private readonly IGemService _gemService;

        public GemController(IGemService gemSerivce)
        {
            _gemService = gemSerivce;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GemResponse>>> GetAllAsync()
        {
            var result = await _gemService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountResponse>> GetByIdAsync(Guid id)
        {
            var result = await _gemService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromForm] CreateGemRequest createModel)
        {
            var id = await _gemService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateGemRequest updateModel)
        {
            try
            {
                await _gemService.UpdateAsync(id, updateModel);
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
                await _gemService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
