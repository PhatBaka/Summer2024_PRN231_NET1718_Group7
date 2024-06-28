using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Material.Gem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/GemOData")]
    [ApiController]
    public class GemController : ODataController
    {
        private readonly IGemService _gemService;

        public GemController(IGemService gemSerivce)
        {
            _gemService = gemSerivce;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GemResponse>>> GetAllAsync()
        {
            var result = await _gemService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GemResponse>> GetByIdAsync(Guid id)
        {
            var result = await _gemService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}

