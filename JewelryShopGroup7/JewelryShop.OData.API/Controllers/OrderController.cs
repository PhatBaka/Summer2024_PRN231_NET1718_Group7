using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.BusinessLayer.Services;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Jewelry;
using JewelryShop.DTO.DTOs.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/OrderOData")]
    [ApiController]
    public class OrderController : ODataController
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
        [EnableQuery]
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
    }
}
