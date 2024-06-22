using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.StoreDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/StoreDiscountOData")]
    [ApiController]
    public class StoreDiscountController : ODataController
    {
        private readonly IStoreDiscountService _storeDiscountService;

        public StoreDiscountController(IStoreDiscountService storeDiscountService)
        {
            _storeDiscountService = storeDiscountService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<StoreDiscountResponse>>> GetAllAsync()
        {
            var result = await _storeDiscountService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDiscountResponse>> GetByIdAsync(Guid id)
        {
            var result = await _storeDiscountService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
     
    }
}
