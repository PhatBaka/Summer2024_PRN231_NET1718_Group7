using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using AutoMapper;

namespace JewelryShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JewelryController : ControllerBase
    {
        private readonly IJewelryService _jewelryService;
        private readonly IMapper _mapper;

        public JewelryController(IJewelryService jewelryService,
                                    IMapper mapper)
        {
            _jewelryService = jewelryService;
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
            var id = await _jewelryService.CreateAsync(_mapper.Map<JewelryDTO>(createJewelryDTO));
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
