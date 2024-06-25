//using AutoMapper;
//using JewelryShop.BusinessLayer.Helpers;
//using JewelryShop.BusinessLayer.Interfaces;
//using JewelryShop.DTO.DTOs;
//using JewelryShop.DTO.DTOs.Material;
//using Microsoft.AspNetCore.Mvc;

//namespace JewelryShop.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MaterialController : ControllerBase
//    {
//        private readonly IMaterialService _materialService;
//        private readonly IMapper _mapper;

//        public MaterialController(IMaterialService materialService,
//                                    IMapper mapper)
//        {
//            _materialService = materialService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetAllAsync()
//        {
//            var result = await _materialService.GetAllAsync();
//            return Ok(result);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<MaterialDTO>> GetByIdAsync(Guid id)
//        {
//            var result = await _materialService.GetByIdAsync(id);
//            if (result == null) return NotFound();
//            return Ok(result);
//        }

//        [HttpPost]
//        public async Task<ActionResult<Guid>> CreateAsync([FromBody] MaterialDTO createModel)
//        {
//            var id = await _materialService.CreateAsync(createModel);
//            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateMaterialRequest updateModel)
//        {
//            try
//            {
//                await _materialService.UpdateAsync(id, updateModel);
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
//                await _materialService.DeleteAsync(id);
//                return NoContent();
//            }
//            catch (KeyNotFoundException)
//            {
//                return NotFound();
//            }
//        }

//        [HttpPost("Gem")]
//        public async Task<ActionResult<Guid>> CreateGemAsync([FromForm] CreateMaterialRequest createModel)
//        {
//            //var gem = _mapper.Map<MaterialDTO>(createModel);
//            //gem.CreatedDate = DateTime.Now;
//            //gem.CertificateImageData = await FileHelper.ConvertToByteArrayAsync(createModel.CertificateImageFile);
//            //gem.MaterialImageData = await FileHelper.ConvertToByteArrayAsync(createModel.MaterialImageFile);
//            //gem.SellPrice = gem.BuyPrice * 70 / 100;
//            var id = await _materialService.CreateAsync(createModel);
//            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
//        }

//        [HttpPost("Metal")]
//        public async Task<ActionResult<Guid>> CreateMetalAsync([FromBody] CreateMaterialRequest createModel)
//        {
//            //var metal = _mapper.Map<MaterialDTO>(createModel);
//            //metal.CreatedDate = DateTime.Now;
//            var id = await _materialService.CreateAsync(createModel);
//            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
//        }
//    }
//}
