using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace JewelryShop.OData.Api.Controllers
{
    [Route("odata/ImageOData")]
    [ApiController]
    public class ImageController : ODataController
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ImageController(IImageService imageService,
                                    IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<ImageDTO>>> GetAllAsync()
        {
            var result = await _imageService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetByIdAsync")]
        public async Task<ActionResult<ImageDTO>> GetByIdAsync(Guid id)
        {
            var result = await _imageService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromForm] CreateImageDTO createImageDTO)
        {
            var id = await _imageService.CreateAsync(_mapper.Map<ImageDTO>(createImageDTO));
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromForm] UpdateImageDTO updateModel)
        {
            try
            {
                await _imageService.UpdateAsync(id, _mapper.Map<ImageDTO>(updateModel));
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
                await _imageService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
