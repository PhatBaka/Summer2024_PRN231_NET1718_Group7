using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs.Material.Gem;
using JewelryShop.DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using JewelryShop.DTO.DTOs.Material.Metal;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/MetalOData")]
    [ApiController]
    public class MetalController : ODataController
    {
        private readonly IMetalService _metalService;

        public MetalController(IMetalService metalService)
        {
            _metalService = metalService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<MetalResponse>>> GetAllAsync()
        {
            var result = await _metalService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MetalResponse>> GetByIdAsync(Guid id)
        {
            var result = await _metalService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}

