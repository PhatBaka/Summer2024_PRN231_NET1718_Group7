using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using Microsoft.AspNetCore.OData.Query;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialPriceController : ControllerBase
    {
        private readonly IMaterialPriceService _materialPriceService;

        public MaterialPriceController(IMaterialPriceService materialPriceService)
        {
            _materialPriceService = materialPriceService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<MaterialPriceDTO>>> GetAllAsync()
        {
            var result = await _materialPriceService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialPriceDTO>> GetByIdAsync(Guid id)
        {
            var result = await _materialPriceService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] MaterialPriceDTO createModel)
        {
            var id = await _materialPriceService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] MaterialPriceDTO updateModel)
        {
            try
            {
                await _materialPriceService.UpdateAsync(id, updateModel);
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
                await _materialPriceService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
