using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Order;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        private readonly IJewelryService _jewelryService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService,
                                IJewelryService jewelryService,
                                IOrderDetailService orderDetailService,
                                IMapper mapper)
        {
            _orderDetailService = orderDetailService;
            _orderService = orderService;
            _jewelryService = jewelryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAllAsync()
        {
            var result = await _orderService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetByIdAsync(Guid id)
        {
            var result = await _orderService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateOrderRequest createModel)
        {
            createModel.TotalPrice = 0;
            //List<JewelryDTO> jewelryDTOs = new List<JewelryDTO>();
            foreach (var item in createModel.OrderDetails)
            {
                var entity = await _jewelryService.GetByIdAsync(item.JewelryId);
                var orderDetail = createModel.OrderDetails.First(x => x.JewelryId == entity.JewelryId);
                orderDetail.UnitPrice = entity.UnitPrice;
                orderDetail.TotalPrice = entity.UnitPrice * orderDetail.Quantity;
                orderDetail.FinalPrice = orderDetail.TotalPrice;
                createModel.TotalPrice += entity.SellPrice;
            }
            // discount o day
            createModel.FinalPrice = createModel.TotalPrice;
            createModel.OrderDate = DateTime.Now;
            var id = await _orderService.CreateAsync(createModel);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateOrderRequest updateModel)
        {
            try
            {
                await _orderService.UpdateAsync(id, updateModel);
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
                await _orderService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
