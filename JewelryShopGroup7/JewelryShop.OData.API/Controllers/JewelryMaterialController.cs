//using JewelryShop.BusinessLayer.Interfaces;
//using JewelryShop.DTO.DTOs;
//using JewelryShop.DTO.DTOs.JewelryMaterial;
//using Microsoft.AspNetCore.Mvc;

//namespace JewelryShop.OData.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class JewelryMaterialController : ControllerBase
//    {
//        private readonly IJewelryMaterialService _jewelryMaterialService;

//        public JewelryMaterialController(IJewelryMaterialService jewelryMaterialService)
//        {
//            _jewelryMaterialService = jewelryMaterialService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<JewelryMaterialResponse>>> GetAllAsync()
//        {
//            var result = await _jewelryMaterialService.GetAllAsync();
//            return Ok(result);
//        }

//        [HttpGet("{jewelryId}/{materialId}")]
//        public async Task<ActionResult<JewelryMaterialResponse>> GetByIdAsync(Guid jewelryId, Guid materialId)
//        {
//            var result = await _jewelryMaterialService.GetByIdAsync(jewelryId, materialId);
//            if (result == null) return NotFound();
//            return Ok(result);
//        }

//        [HttpPost]
//        public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateJewelryMaterialRequest createModel)
//        {
//            var id = await _jewelryMaterialService.CreateAsync(createModel);
//            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
//        }

//        [HttpPut("{jewelryId}/{materialId}")]
//        public async Task<IActionResult> UpdateAsync(Guid jewelryId, Guid materialId, [FromBody] UpdateJewelryMaterialRequest updateModel)
//        {
//            try
//            {
//                await _jewelryMaterialService.UpdateAsync(jewelryId, materialId, updateModel);
//                return NoContent();
//            }
//            catch (KeyNotFoundException)
//            {
//                return NotFound();
//            }
//        }

//        [HttpDelete("{jewelryId}/{materialId}")]
//        public async Task<IActionResult> DeleteAsync(Guid jewelryId, Guid materialId)
//        {
//            try
//            {
//                await _jewelryMaterialService.DeleteAsync(jewelryId, materialId);
//                return NoContent();
//            }
//            catch (KeyNotFoundException)
//            {
//                return NotFound();
//            }
//        }
//    }
//}
