using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Jewelry;
using JewelryShop.DTO.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/JewelryOData")]
    [ApiController]
    public class JewelryController : ODataController
    {
        private readonly IJewelryService _jewelryService;
        private readonly IMapper _mapper;

        public JewelryController(IJewelryService jewelryService,
                                    IMapper mapper)
        {
            _jewelryService = jewelryService;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<JewelryResponse>>> GetAllAsync()
        {
            var result = await _jewelryService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JewelryResponse>> GetByIdAsync(Guid id)
        {
            var result = await _jewelryService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
