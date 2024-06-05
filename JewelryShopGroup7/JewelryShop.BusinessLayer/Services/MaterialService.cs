using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Guid> CreateAsync(MaterialDTO createModel)
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

        public async Task<IEnumerable<MaterialDTO>> GetAllAsync()
        {
            var materials = await _materialRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaterialDTO>>(materials.ToList());
        }

        public async Task<MaterialDTO> GetByIdAsync(Guid id)
        {
            var material = (await _materialRepository.GetAsync(m => m.MaterialId == id)).FirstOrDefault();
            return _mapper.Map<MaterialDTO>(material);
        }

        public async Task UpdateAsync(Guid id, MaterialDTO updateModel)
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
