using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.OrderDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/OrderDiscountOData")]
    [ApiController]
    public class OrderDiscountController : ODataController
    {
        private readonly IOrderDiscountService _orderDiscountService;

        public OrderDiscountController(IOrderDiscountService orderDiscountService)
        {
            _orderDiscountService = orderDiscountService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<OrderDiscountResponse>>> GetAllAsync()
        {
            var result = await _orderDiscountService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDiscountResponse>> GetByIdAsync(Guid id)
        {
            var result = await _orderDiscountService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

    }
}
