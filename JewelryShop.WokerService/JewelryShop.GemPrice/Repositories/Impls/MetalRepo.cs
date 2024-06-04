using JewelryShop.GemPrice.DataAccessObjects.Interfaces;
using JewelryShop.GemPrice.Models;
using JewelryShop.GemPrice.Repositories.Interfaces;

namespace JewelryShop.GemPrice.Repositories.Impls
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
