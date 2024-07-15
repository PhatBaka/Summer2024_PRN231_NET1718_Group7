using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Material;

namespace JewelryShop.BusinessLayer.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateMaterialRequest createModel)
        {

            Material material = _mapper.Map<Material>(createModel);
            return await _materialRepository.AddAsync(material);
        }

        public async Task<Guid> CreateMaAsync(CreatePriceDTO createModel)
        {
            Material material = _mapper.Map<Material>(createModel);
            return await _materialRepository.AddAsync(material);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var material = (await _materialRepository.GetAsync(m => m.MaterialId == id)).FirstOrDefault();
                if (material != null)
                {
                    await _materialRepository.RemoveAsync(material);
                }
                else
                {
                    throw new KeyNotFoundException("Material not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<MaterialResponse> findAsync(string type)
        {
            var material = (await _materialRepository.GetAsync(m => m.Name == type)).FirstOrDefault();
            return _mapper.Map<MaterialResponse>(material);
        }

        public async Task<IEnumerable<MaterialResponse>> GetAllAsync()
        {
            var materials = await _materialRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaterialResponse>>(materials.ToList());
        }

        public async Task<MaterialResponse> GetByIdAsync(Guid id)
        {
            var material = (await _materialRepository.GetAsync(m => m.MaterialId == id)).FirstOrDefault();
            return _mapper.Map<MaterialResponse>(material);
        }

        public async Task UpdateAsync(Guid id, UpdateMaterialRequest updateModel)
        {
            var material = (await _materialRepository.GetAsync(m => m.MaterialId == id)).FirstOrDefault();
            if (material != null)
            {
                var updateMaterial = _mapper.Map(updateModel, material);
                await _materialRepository.UpdateAsync(updateMaterial);
            }
            else
            {
                throw new KeyNotFoundException("Material not found.");
            }
        }

        public async Task UpdateMaAsync(Guid id, MaterialResponse updateModel)
        {
            var material = (await _materialRepository.GetAsync(m => m.MaterialId == id)).FirstOrDefault();
            if (material != null)
            {
                var updateMaterial = _mapper.Map(updateModel, material);
                await _materialRepository.UpdateAsync(updateMaterial);
            }
            else
            {
                throw new KeyNotFoundException("Material not found.");
            }
        }
    }
}
