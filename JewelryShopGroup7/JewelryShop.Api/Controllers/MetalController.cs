using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs.Account;
using JewelryShop.DTO.DTOs.Material.Gem;
using JewelryShop.DTO.DTOs.Material.Metal;
using JewelryShop.DTO.Enums;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetalController : ControllerBase
    {
        private readonly IMetalService _metalService;

        public MetalController(IMetalService metalService)
        {
            _metalService = metalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetalResponse>>> GetAllAsync()
        {
            var result = await _metalService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MetalResponse>> GetByIdAsync(Guid id)
        {
            var result = await _metalService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromQuery] MetalEnum metalEnum, [FromQuery] MaterialStatus materialStatus, [FromBody] CreateMetalRequest createModel)
        {
            createModel.MaterialStatus = materialStatus;
            createModel.Name = metalEnum.ToString();
            var id = await _metalService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateMetalRequest updateModel)
        {
            try
            {
                await _metalService.UpdateAsync(id, updateModel);
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
                await _metalService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
