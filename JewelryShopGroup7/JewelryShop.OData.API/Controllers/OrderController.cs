//using AutoMapper;
//using JewelryShop.BusinessLayer.Interfaces;
//using JewelryShop.DTO.DTOs;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Query;
//using Microsoft.AspNetCore.OData.Routing.Controllers;

//namespace JewelryShop.OData.Api.Controllers
//{
//    [Route("odata/OrderOData")]
//    [ApiController]
//    public class OrderController : ODataController
//    {
//        private readonly IOrderDetailService _orderDetailService;
//        private readonly IOrderService _orderService;
//        private readonly IJewelryService _jewelryService;
//        private readonly IMapper _mapper;

//        public OrderController(IOrderService orderService,
//                                IJewelryService jewelryService,
//                                IOrderDetailService orderDetailService,
//                                IMapper mapper)
//        {
//            _orderDetailService = orderDetailService;
//            _orderService = orderService;
//            _jewelryService = jewelryService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        [EnableQuery]
//        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllAsync()
//        {
//            var result = await _orderService.GetAllAsync();
//            return Ok(result);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<OrderDTO>> GetByIdAsync(Guid id)
//        {
//            var result = await _orderService.GetByIdAsync(id);
//            if (result == null) return NotFound();
//            return Ok(result);
//        }

//        [HttpPost]
//        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateOrderDTO createModel)
//        {
//            createModel.TotalPrice = 0;
//            foreach (var item in createModel.OrderDetails)
//            {
//                var entity = await _jewelryService.GetByIdAsync((Guid)item.JewelryId);
//                var orderDetail = createModel.OrderDetails.First(x => x.JewelryId == entity.JewelryId);
//                orderDetail.UnitPrice = entity.UnitPrice;
//                orderDetail.TotalPrice = entity.UnitPrice * orderDetail.Quantity;
//                orderDetail.FinalPrice = orderDetail.TotalPrice;
//                createModel.TotalPrice += entity.SellPrice;
//            }
//            // discount o day
//            createModel.FinalPrice = createModel.TotalPrice;
//            createModel.OrderDate = DateTime.Now;
//            var id = await _orderService.CreateAsync(_mapper.Map<OrderDTO>(createModel));
//            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] OrderDTO updateModel)
//        {
//            try
//            {
//                await _orderService.UpdateAsync(id, updateModel);
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
//                await _orderService.DeleteAsync(id);
//                return NoContent();
//            }
//            catch (KeyNotFoundException)
//            {
//                return NotFound();
//            }
//        }
//    }
//}
