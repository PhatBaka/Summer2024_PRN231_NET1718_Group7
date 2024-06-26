using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Offer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/OfferOData")]
    [ApiController]
    public class OfferController : ODataController
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<OfferResponse>>> GetAllAsync()
        {
            var result = await _offerService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfferResponse>> GetByIdAsync(Guid id)
        {
            var result = await _offerService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
