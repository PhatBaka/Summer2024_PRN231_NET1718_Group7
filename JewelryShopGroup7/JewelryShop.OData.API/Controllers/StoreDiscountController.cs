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
    public class StoreDiscountController : ControllerBase
    {
        private readonly IStoreDiscountService _storeDiscountService;

        public StoreDiscountController(IStoreDiscountService storeDiscountService)
        {
            _storeDiscountService = storeDiscountService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<StoreDiscountDTO>>> GetAllAsync()
        {
            var result = await _storeDiscountService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDiscountDTO>> GetByIdAsync(Guid id)
        {
            var result = await _storeDiscountService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] StoreDiscountDTO createModel)
        {
            var id = await _storeDiscountService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] StoreDiscountDTO updateModel)
        {
            try
            {
                await _storeDiscountService.UpdateAsync(id, updateModel);
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
                await _storeDiscountService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}