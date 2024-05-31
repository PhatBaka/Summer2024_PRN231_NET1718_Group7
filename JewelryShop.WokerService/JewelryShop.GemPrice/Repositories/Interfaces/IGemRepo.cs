using JewelryShop.GemPrice.Models;

namespace JewelryShop.GemPrice.Repositories.Interfaces
{
	public interface IGemRepo
	{
		public Task<IEnumerable<Gem>> GetGems();
	}
}
