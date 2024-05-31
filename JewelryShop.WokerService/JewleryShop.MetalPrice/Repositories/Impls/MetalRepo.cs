using JewleryShop.MetalPrice.DataAccessObjects.Interfaces;
using JewleryShop.MetalPrice.Models;
using JewleryShop.MetalPrice.Repositories.Interfaces;

namespace JewleryShop.MetalPrice.Repositories.Impls
{
	public class MetalRepo : IMetalRepo
	{
		private readonly IGenericDAO<Metal> genericDAO;

		public MetalRepo(IGenericDAO<Metal> genericDAO)
		{
			this.genericDAO = genericDAO;
		}

		public async Task<IEnumerable<Metal>> GetMetals()
		{
			try
			{
				return await genericDAO.GetAllAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
