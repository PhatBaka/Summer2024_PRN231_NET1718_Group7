using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuaranteeController : ControllerBase
    {
        private readonly IGuaranteeService _guaranteeService;

        public GuaranteeController(IGuaranteeService guaranteeService)
        {
            _guaranteeService = guaranteeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuaranteeDTO>>> GetAllAsync()
        {
            var result = await _guaranteeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuaranteeDTO>> GetByIdAsync(Guid id)
        {
            var result = await _guaranteeService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] GuaranteeDTO createModel)
        {
            var id = await _guaranteeService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }
        [HttpPost("addtoorder")]
        public async Task<ActionResult<Guid>> AddtoOrderAsync([FromBody] GuaranteeDTO createModel, Guid Orderid)
        {
            try
            {
                await _guaranteeService.CreateofOrderAsync(createModel, Orderid);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] GuaranteeDTO updateModel)
        {
            try
            {
                await _guaranteeService.UpdateAsync(id, updateModel);
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
                await _guaranteeService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
