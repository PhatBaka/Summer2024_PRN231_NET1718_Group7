using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/MaterialOData")]
    [ApiController]
    public class MaterialController : ODataController
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetAllAsync()
        {
            var result = await _materialService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialDTO>> GetByIdAsync(Guid id)
        {
            var result = await _materialService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] MaterialDTO createModel)
        {
            var id = await _materialService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] MaterialDTO updateModel)
        {
            try
            {
                await _materialService.UpdateAsync(id, updateModel);
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
                await _materialService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
