using JewelryShop.GemPrice.Models;
using JewelryShop.GemPrice.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JewelryShop.GemPrice.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GemController : ControllerBase
	{
		private readonly IGemRepo gemRepo;

		public GemController(IGemRepo gemRepo)
		{
			this.gemRepo = gemRepo;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Gem>>> GettAllAsync()
		{
			var result = await gemRepo.GetGems();
			return Ok(result);
		}
	}
}
