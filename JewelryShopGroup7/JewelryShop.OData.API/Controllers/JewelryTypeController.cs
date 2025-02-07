//using JewelryShop.BusinessLayer.Interfaces;
//using JewelryShop.DTO.DTOs;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Query;
//using Microsoft.AspNetCore.OData.Routing.Controllers;

//namespace JewelryShop.OData.Api.Controllers
//{
//    [Route("odata/JewelryTypeOData")]
//    [ApiController]
//    public class JewelryTypeController : ODataController
//    {
//        private readonly IJewelryTypeService _jewelryTypeService;

//        public JewelryTypeController(IJewelryTypeService jewelryTypeService)
//        {
//            _jewelryTypeService = jewelryTypeService;
//        }

//        [HttpGet]
//        [EnableQuery]
//        public async Task<ActionResult<IEnumerable<JewelryTypeDTO>>> GetAllAsync()
//        {
//            var result = await _jewelryTypeService.GetAllAsync();
//            return Ok(result);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<JewelryTypeDTO>> GetByIdAsync(Guid id)
//        {
//            var result = await _jewelryTypeService.GetByIdAsync(id);
//            if (result == null) return NotFound();
//            return Ok(result);
//        }

//        [HttpPost]
//        public async Task<ActionResult<Guid>> CreateAsync([FromBody] JewelryTypeDTO createModel)
//        {
//            var id = await _jewelryTypeService.CreateAsync(createModel);
//            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] JewelryTypeDTO updateModel)
//        {
//            try
//            {
//                await _jewelryTypeService.UpdateAsync(id, updateModel);
//                return NoContent();
//            }
//            catch (KeyNotFoundException)
//            {
//                return NotFound();
//            }
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAsync(Guid id)
//        {
//            try
//            {
//                await _jewelryTypeService.DeleteAsync(id);
//                return NoContent();
//            }
//            catch (KeyNotFoundException)
//            {
//                return NotFound();
//            }
//        }
//    }
//}
