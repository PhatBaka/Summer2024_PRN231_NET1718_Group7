using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using AutoMapper;
using JewelryShop.DTO.Enums;
using JewelryShop.DAL.Repositories.Interface;
using JewelryShop.DAL.Models;

namespace JewelryShop.API.Controllers
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
        public async Task<ActionResult<IEnumerable<JewelryDTO>>> GetAllAsync()
        {
            var result = await _jewelryService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JewelryDTO>> GetByIdAsync(Guid id)
        {
            var result = await _jewelryService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateJewelryDTO createJewelryDTO)
		{
            foreach (var material in createJewelryDTO.CreateJewelryMeterialDTOs)
            {
                var entity = await _materialService.GetByIdAsync((Guid)material.MaterialId);
                createJewelryDTO.TotalWeight += material.Weight;
				createJewelryDTO.UnitPrice += material.Weight * entity.Price;
			}
			createJewelryDTO.UnitPrice += (decimal) createJewelryDTO.ManufacturingFees;
            createJewelryDTO.SellPrice = createJewelryDTO.UnitPrice + (createJewelryDTO.UnitPrice * createJewelryDTO.MarkupPercentage);
            createJewelryDTO.Status = ObjectStatus.ACTIVE.ToString();
            var id = await _jewelryService.CreateAsync(_mapper.Map<JewelryDTO>(createJewelryDTO));
            foreach (var material in createJewelryDTO.CreateJewelryMeterialDTOs)
            {
                var weight = await _materialService.GetByIdAsync((Guid)material.MaterialId);
				JewelryMaterialDTO jewelryMaterialDTO = new JewelryMaterialDTO()
                {
                    JewelryId = id,
                    MaterialId = (Guid) material.MaterialId,
                    Weight = material.Weight,
                    ImportTime = DateTime.Now,
                    Price = material.Weight * weight.Price
				};
                await _jewelryMaterialService.CreateAsync(jewelryMaterialDTO);
            }
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] JewelryDTO updateModel)
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
