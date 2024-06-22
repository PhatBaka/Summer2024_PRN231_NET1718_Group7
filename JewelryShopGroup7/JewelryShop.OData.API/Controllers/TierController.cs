using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Tier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/TierOData")]
    [ApiController]
    public class TierController : ODataController
    {
        private readonly ITierService _tierService;

        public TierController(ITierService tierService)
        {
            _tierService = tierService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<TierResponse>>> GetAllAsync()
        {
            var result = await _tierService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TierResponse>> GetByIdAsync(Guid id)
        {
            var result = await _tierService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }    
    }
}
