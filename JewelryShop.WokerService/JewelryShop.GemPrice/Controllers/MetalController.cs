using JewelryShop.GemPrice.Models;
using JewelryShop.GemPrice.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.GemPrice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetalController : ControllerBase
    {
        private readonly IMetalRepo metalRepo;

        public MetalController(IMetalRepo metalRepo)
        {
            this.metalRepo = metalRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Metal>>> GettAllAsync()
        {
            var result = await metalRepo.GetMetals();
            return Ok(result);
        }
    }
}
