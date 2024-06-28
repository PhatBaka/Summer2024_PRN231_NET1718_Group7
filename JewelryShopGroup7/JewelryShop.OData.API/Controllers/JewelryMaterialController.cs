//using JewelryShop.BusinessLayer.Interfaces;
//using JewelryShop.DTO.DTOs;
//using JewelryShop.DTO.DTOs.JewelryMaterial;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.OData.Query;

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
//        [EnableQuery]
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

//    }
//}
