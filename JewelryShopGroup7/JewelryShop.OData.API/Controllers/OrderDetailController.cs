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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<OrderDetailDTO>>> GetAllAsync()
        {
            var result = await _orderDetailService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailDTO>> GetByIdAsync(Guid id)
        {
            var result = await _orderDetailService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] OrderDetailDTO createModel)
        {
            var id = await _orderDetailService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] OrderDetailDTO updateModel)
        {
            try
            {
                await _orderDetailService.UpdateAsync(id, updateModel);
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
                await _orderDetailService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
