using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Customer;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetAllAsync()
        {
            var result = await _customerService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("phone/{phoneNumber}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerByPhoneAsync(string phoneNumber)
        {
            var result = await _customerService.GetAllAsync();
            return Ok(result.FirstOrDefault(x => x.PhoneNumber == phoneNumber));
        }


        [HttpGet("id/{id}")]
        public async Task<ActionResult<CustomerResponse>> GetByIdAsync(Guid id)
        {
            var result = await _customerService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateCustomerRequest createModel)
        {
            var id = await _customerService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateCustomerRequest updateModel)
        {
            try
            {
                await _customerService.UpdateAsync(id, updateModel);
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
                await _customerService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
