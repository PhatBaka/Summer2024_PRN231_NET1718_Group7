using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Jewelry;
using JewelryShop.DTO.DTOs.JewelryMaterial;
using JewelryShop.DTO.Enums;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JewelryController : ControllerBase
    {
        private readonly IJewelryService _jewelryService;
        private readonly IJewelryMaterialService _jewelryMaterialService;
        private readonly IMaterialService _materialService;
        private readonly IMapper _mapper;

        public JewelryController(IJewelryService jewelryService,
                                    IJewelryMaterialService jewelryMaterialService,
                                    IMaterialService materialService,
                                    IMapper mapper)
        {
            _materialService = materialService;
            _jewelryMaterialService = jewelryMaterialService;
            _jewelryService = jewelryService;
            _mapper = mapper;
        }

        [HttpGet]
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

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateJewelryRequest createJewelryDTO)
        {
            foreach (var material in createJewelryDTO.CreateJewelryMeterialRequests)
            {
                var entity = await _materialService.GetByIdAsync((Guid)material.MaterialId);
                createJewelryDTO.TotalWeight += material.Weight;
                createJewelryDTO.UnitPrice += material.Weight * entity.Price;
            }
            createJewelryDTO.UnitPrice += createJewelryDTO.ManufacturingFees;
            createJewelryDTO.SellPrice = createJewelryDTO.UnitPrice + createJewelryDTO.UnitPrice * createJewelryDTO.MarkupPercentage / 100;
            createJewelryDTO.Status = ObjectStatus.ACTIVE.ToString();
            var id = await _jewelryService.CreateAsync(createJewelryDTO);
            foreach (var material in createJewelryDTO.CreateJewelryMeterialRequests)
            {
                var weight = await _materialService.GetByIdAsync((Guid)material.MaterialId);
                CreateJewelryMaterialRequest jewelryMaterialDTO = new CreateJewelryMaterialRequest()
                {
                    JewelryId = id,
                    MaterialId = (Guid)material.MaterialId,
                    Weight = material.Weight,
                };
                await _jewelryMaterialService.CreateAsync(jewelryMaterialDTO);
            }
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateJewelryRequest updateModel)
        {
            try
            {
                await _jewelryService.UpdateAsync(id, updateModel);
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
                await _jewelryService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
