using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Guarantee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/GuaranteeOData")]
    [ApiController]
    public class GuaranteeController : ODataController
    {
        private readonly IGuaranteeService _guaranteeService;

        public GuaranteeController(IGuaranteeService guaranteeService)
        {
            _guaranteeService = guaranteeService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GuaranteeResponse>>> GetAllAsync()
        {
            var result = await _guaranteeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuaranteeResponse>> GetByIdAsync(Guid id)
        {
            var result = await _guaranteeService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateGuaranteeRequest createModel)
        {
            var id = await _guaranteeService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateGuaranteeRequest updateModel)
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
