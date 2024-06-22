using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Guarantee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/GuaranteeOData")]
    [ApiController]
    public class GuaranteeController : ODataController
    {
        private readonly IGuaranteeService _guaranteeService;

        public GuaranteeController(IGuaranteeService guaranteeService)
        {
            _guaranteeService = guaranteeService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GuaranteeResponse>>> GetAllAsync()
        {
            var result = await _guaranteeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuaranteeResponse>> GetByIdAsync(Guid id)
        {
            var result = await _guaranteeService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

    }
}
