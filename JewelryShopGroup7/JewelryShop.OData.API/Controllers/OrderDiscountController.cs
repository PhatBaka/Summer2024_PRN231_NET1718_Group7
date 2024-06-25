//using JewelryShop.BusinessLayer.Interfaces;
//using JewelryShop.DTO.DTOs;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Query;
//using Microsoft.AspNetCore.OData.Routing.Controllers;

//namespace JewelryShop.OData.Api.Controllers
//{
//    [Route("odata/OrderDiscountOData")]
//    [ApiController]
//    public class OrderDiscountController : ODataController
//    {
//        private readonly IOrderDiscountService _orderDiscountService;

//        public OrderDiscountController(IOrderDiscountService orderDiscountService)
//        {
//            _orderDiscountService = orderDiscountService;
//        }

//        [HttpGet]
//        [EnableQuery]
//        public async Task<ActionResult<IEnumerable<OrderDiscountDTO>>> GetAllAsync()
//        {
//            var result = await _orderDiscountService.GetAllAsync();
//            return Ok(result);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<OrderDiscountDTO>> GetByIdAsync(Guid id)
//        {
//            var result = await _orderDiscountService.GetByIdAsync(id);
//            if (result == null) return NotFound();
//            return Ok(result);
//        }

//        [HttpPost]
//        public async Task<ActionResult<Guid>> CreateAsync([FromBody] OrderDiscountDTO createModel)
//        {
//            var id = await _orderDiscountService.CreateAsync(createModel);
//            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] OrderDiscountDTO updateModel)
//        {
//            try
//            {
//                await _orderDiscountService.UpdateAsync(id, updateModel);
//                return NoContent();
//            }
//            catch (KeyNotFoundException)
//            {
//                return NotFound();
//            }
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAsync(Guid id)
//        {
//            try
//            {
//                await _orderDiscountService.DeleteAsync(id);
//                return NoContent();
//            }
//            catch (KeyNotFoundException)
//            {
//                return NotFound();
//            }
//        }
//    }
//}
