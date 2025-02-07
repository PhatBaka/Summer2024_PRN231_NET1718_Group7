//using JewelryShop.BusinessLayer.Interfaces;
//using JewelryShop.DTO;
//using JewelryShop.DTO.DTOs;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Query;
//using Microsoft.AspNetCore.OData.Routing.Controllers;

//namespace JewelryShop.OData.Api.Controllers
//{
//    [Route("odata/TierOData")]
//    [ApiController]
//    public class TierController : ODataController
//    {
//        private readonly ITierService _tierService;

//        public TierController(ITierService tierService)
//        {
//            _tierService = tierService;
//        }

//        [HttpGet]
//        [EnableQuery]
//        public async Task<ActionResult<IEnumerable<TierDTO>>> GetAllAsync()
//        {
//            var result = await _tierService.GetAllAsync();
//            return Ok(result);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<TierDTO>> GetByIdAsync(Guid id)
//        {
//            var result = await _tierService.GetByIdAsync(id);
//            if (result == null) return NotFound();
//            return Ok(result);
//        }

//        [HttpPost]
//        public async Task<ActionResult<Guid>> CreateAsync([FromBody] TierDTO createModel)
//        {
//            var id = await _tierService.CreateAsync(createModel);
//            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] TierDTO updateModel)
//        {
//            try
//            {
//                await _tierService.UpdateAsync(id, updateModel);
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
//                await _tierService.DeleteAsync(id);
//                return NoContent();
//            }
//            catch (KeyNotFoundException)
//            {
//                return NotFound();
//            }
//        }
//    }
//}
