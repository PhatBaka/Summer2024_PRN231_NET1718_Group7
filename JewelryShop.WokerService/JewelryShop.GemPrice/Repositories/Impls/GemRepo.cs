using JewelryShop.GemPrice.DataAccessObjects.Interfaces;
using JewelryShop.GemPrice.Models;
using JewelryShop.GemPrice.Repositories.Interfaces;

namespace JewelryShop.GemPrice.Repositories.Impls
{
	public class GemRepo : IGemRepo
	{
		private readonly IGenericDAO<Gem> genericDAO;

		public GemRepo(IGenericDAO<Gem> genericDAO)
		{
			this.genericDAO = genericDAO;
		}

		public async Task<IEnumerable<Gem>> GetGems()
		{
			try
			{
				var result = await genericDAO.GetAllAsync();
				return result;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
