using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Tier;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TierController : ControllerBase
    {
        private readonly ITierService _tierService;

        public TierController(ITierService tierService)
        {
            _tierService = tierService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TierResponse>>> GetAllAsync()
        {
            var result = await _tierService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TierResponse>> GetByIdAsync(Guid id)
        {
            var result = await _tierService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateTierRequest createModel)
        {
            var id = await _tierService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateTierRequest updateModel)
        {
            try
            {
                await _tierService.UpdateAsync(id, updateModel);
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
                await _tierService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
