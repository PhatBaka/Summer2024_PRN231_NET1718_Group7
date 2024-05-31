using JewleryShop.MetalPrice.Models;
using JewleryShop.MetalPrice.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JewleryShop.MetalPrice.Controllers
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
