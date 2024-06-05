using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;

namespace JewelryShop.BusinessLayer.Services
{
    public class MaterialPriceService : IMaterialPriceService
    {
        private readonly IMaterialPriceRepository _materialPriceRepository;
        private readonly IMapper _mapper;

        public MaterialPriceService(IMaterialPriceRepository materialPriceRepository, IMapper mapper)
        {
            _materialPriceRepository = materialPriceRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(MaterialPriceDTO createModel)
        {
            MaterialPrice materialPrice = _mapper.Map<MaterialPrice>(createModel);
            return await _materialPriceRepository.AddAsync(materialPrice);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var materialPrice = (await _materialPriceRepository.GetAsync(mp => mp.MaterialPriceId == id)).FirstOrDefault();
                if (materialPrice != null)
                {
                    await _materialPriceRepository.RemoveAsync(materialPrice);
                }
                else
                {
                    throw new KeyNotFoundException("Material Price not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<MaterialPriceDTO>> GetAllAsync()
        {
            var materialPrices = await _materialPriceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaterialPriceDTO>>(materialPrices.ToList());
        }

        public async Task<MaterialPriceDTO> GetByIdAsync(Guid id)
        {
            var materialPrice = (await _materialPriceRepository.GetAsync(mp => mp.MaterialPriceId == id)).FirstOrDefault();
            return _mapper.Map<MaterialPriceDTO>(materialPrice);
        }

        public async Task UpdateAsync(Guid id, MaterialPriceDTO updateModel)
        {
            var materialPrice = (await _materialPriceRepository.GetAsync(mp => mp.MaterialPriceId == id)).FirstOrDefault();
            if (materialPrice != null)
            {
                var updateMaterialPrice = _mapper.Map(updateModel, materialPrice);
                await _materialPriceRepository.UpdateAsync(updateMaterialPrice);
            }
            else
            {
                throw new KeyNotFoundException("Material Price not found.");
            }
        }
    }
}
