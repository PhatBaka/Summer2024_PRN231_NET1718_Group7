﻿using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Image;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
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
        public async Task<ActionResult<IEnumerable<CreateImageRequest>>> GetAllAsync()
        {
            var result = await _imageService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetByIdAsync")]
        public async Task<ActionResult<ImageResponse>> GetByIdAsync(Guid id)
        {
            var result = await _imageService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAsync([FromForm] CreateImageRequest createImageDTO)
        {
            var id = await _imageService.CreateAsync(createImageDTO);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromForm] UpdateImageRequest updateModel)
        {
            try
            {
                await _imageService.UpdateAsync(id, updateModel);
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
