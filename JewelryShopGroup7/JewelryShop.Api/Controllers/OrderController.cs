using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Jewelry;
using JewelryShop.DTO.DTOs.Material;
using JewelryShop.DTO.DTOs.Material.Metal;
using JewelryShop.DTO.DTOs.Order;
using JewelryShop.DTO.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JewelryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        private readonly IJewelryService _jewelryService;
        private readonly IOrderDiscountService _orderDiscountService;
        private readonly IMaterialService _materialService;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        public OrderController(IOrderService orderService,
                                IJewelryService jewelryService,
                                IOrderDetailService orderDetailService,
                                IMapper mapper,
                                IOrderDiscountService orderDiscountService,
                                IMaterialService materialService,
                                HttpClient httpClient)
        {
            _orderDetailService = orderDetailService;
            _orderService = orderService;
            _jewelryService = jewelryService;
            _mapper = mapper;
            _orderDiscountService = orderDiscountService;
            _materialService = materialService;
            _httpClient = httpClient;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAllAsync()
        //{
        //    var result = await _orderService.GetAllAsync();
        //    return Ok(result);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetByIdAsync(Guid id)
        {
            var result = await _orderService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateOrderRequest createModel, string? tiername, string? OrderDiscountCode, decimal? offerPercent, OrderTypeEnum orderTypeEnum)
        {
            //createModel.TotalPrice = 0;
            //List<CreateJewelryRequest> jewelryDTOs = new List<CreateJewelryRequest>();
            //foreach (var item in createModel.OrderDetails)
            //{
            //    var entity = await _jewelryService.GetByIdAsync((Guid)item.JewelryId);
            //    var orderDetail = createModel.OrderDetails.First(x => x.JewelryId == entity.JewelryId);
            //    orderDetail.UnitPrice = entity.UnitPrice;
            //    orderDetail.TotalPrice = entity.UnitPrice * orderDetail.Quantity;
            //    orderDetail.FinalPrice = orderDetail.TotalPrice;
            //    // createModel.TotalPrice += entity.SellPrice;
            //}
            //// discount o day
            //var iddis = _orderDiscountService.UpdateDiscount(tiername, OrderDiscountCode, offerPercent, createModel.TotalPrice).Result;
            //var discount = _orderDiscountService.GetByIdAsync(iddis);
            //createModel.FinalPrice = createModel.TotalPrice - discount.Result.Value;
            //createModel.OrderDate = DateTime.Now;
            //createModel.OrderDiscountId = iddis;
            createModel.OrderType = orderTypeEnum.ToString();
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
        [HttpPost("UpdateMaterialadd")]
        public async Task<ActionResult<Guid>> UpdateMaterialAsync(string Type)
        {
            try
            {
                        var mate = await _materialService.GetAllAsync();

                        var upmate = new MaterialResponse();
                        /*var upmate = mate.OrderByDescending(m => m.CreatedDate)
                                 .FirstOrDefault(m => m.Name == Type);*/
                if (upmate.CreatedDate != DateTime.Now || upmate.ToString().IsNullOrEmpty())
                {
                    var apiUrl = $"https://api.metals.dev/v1/metal/spot?api_key=06AIPD6FBNZWBELRKZDA430LRKZDA&metal={Type}&currency=USD";
                    var response = await _httpClient.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var metalResponse = JsonSerializer.Deserialize<PriceResponse>(content);
                        if (metalResponse != null)
                        {
                            try
                            {
                                CreatePriceDTO createPriceDTO = new CreatePriceDTO();
                                createPriceDTO.CreatedDate = DateTime.Now;
                                createPriceDTO.CurrentPrice = metalResponse.Rate.Price;
                                createPriceDTO.BuyPrice = metalResponse.Rate.Ask;
                                createPriceDTO.SellPrice = metalResponse.Rate.Bid;
                                createPriceDTO.IsMetal = true;
                                createPriceDTO.Weight = 1;
                                createPriceDTO.Name = Type;

                                _materialService.CreateMaAsync(createPriceDTO);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
                           
                 
                return NoContent();

            }
            catch {
                return NotFound();
            }
        }

        }
}
