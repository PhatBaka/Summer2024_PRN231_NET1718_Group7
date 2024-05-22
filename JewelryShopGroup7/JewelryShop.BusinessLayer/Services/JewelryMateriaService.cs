using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interface;
using JewelryShop.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.BusinessLayer.Services
{
    public class JewelryMaterialService : IJewelryMaterialService
    {
        private readonly IJewelryMaterialRepository _jewelryMaterialRepository;
        private readonly IMapper _mapper;

        public JewelryMaterialService(IJewelryMaterialRepository jewelryMaterialRepository, IMapper mapper)
        {
            _jewelryMaterialRepository = jewelryMaterialRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(JewelryMaterialDTO createModel)
        {
            JewelryMaterial jewelryMaterial = _mapper.Map<JewelryMaterial>(createModel);
            return await _jewelryMaterialRepository.AddAsync(jewelryMaterial);
        }

        public async Task DeleteAsync(Guid jewelryId, Guid materialId)
        {
            try
            {
                var jewelryMaterial = (await _jewelryMaterialRepository.GetAsync(j => j.JewelryId == jewelryId && j.MaterialId == materialId)).FirstOrDefault();
                if (jewelryMaterial != null)
                {
                    await _jewelryMaterialRepository.RemoveAsync(jewelryMaterial);
                }
                else
                {
                    throw new KeyNotFoundException("Jewelry Material not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<JewelryMaterialDTO>> GetAllAsync()
        {
            var jewelryMaterials = await _jewelryMaterialRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<JewelryMaterialDTO>>(jewelryMaterials.ToList());
        }

        public async Task<JewelryMaterialDTO> GetByIdAsync(Guid jewelryId, Guid materialId)
        {
            var jewelryMaterial = (await _jewelryMaterialRepository.GetAsync(j => j.JewelryId == jewelryId && j.MaterialId == materialId)).FirstOrDefault();
            return _mapper.Map<JewelryMaterialDTO>(jewelryMaterial);
        }

        public async Task UpdateAsync(Guid jewelryId, Guid materialId, JewelryMaterialDTO updateModel)
        {
            var jewelryMaterial = (await _jewelryMaterialRepository.GetAsync(j => j.JewelryId == jewelryId && j.MaterialId == materialId)).FirstOrDefault();
            if (jewelryMaterial != null)
            {
                var updateJewelryMaterial = _mapper.Map(updateModel, jewelryMaterial);
                await _jewelryMaterialRepository.UpdateAsync(updateJewelryMaterial);
            }
            else
            {
                throw new KeyNotFoundException("Jewelry Material not found.");
            }
        }
    }
}
