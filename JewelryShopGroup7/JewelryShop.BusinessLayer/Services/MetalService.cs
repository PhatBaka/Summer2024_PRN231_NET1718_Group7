using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs.Material.Gem;
using JewelryShop.DTO.DTOs.Material.Metal;
using JewelryShop.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.BusinessLayer.Services
{
    public class MetalService : IMetalService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MetalService(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateMetalRequest createModel)
        {
            Material material = _mapper.Map<Material>(createModel);
            if (material.MaterialStatus.Equals(MaterialStatus.SELL.ToString()))
            {
                material.SellPrice = material.CurrentPrice * material.Weight;
            }
            else if (material.MaterialStatus.Equals(MaterialStatus.BUY.ToString()))
            {
                material.BuyPrice = material.CurrentPrice * material.Weight;
            }
            return await _materialRepository.AddAsync(material);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var gem = (await _materialRepository.GetAsync(c => c.MaterialId == id)).FirstOrDefault();
                if (gem != null)
                {
                    await _materialRepository.RemoveAsync(gem);
                }
                else
                {
                    throw new KeyNotFoundException("Metal not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<MetalResponse>> GetAllAsync()
        {
            var gems = await _materialRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MetalResponse>>(gems.ToList());
        }

        public async Task<MetalResponse> GetByIdAsync(Guid id)
        {
            var gem = (await _materialRepository.GetAsync(c => c.MaterialId == id)).FirstOrDefault();
            return _mapper.Map<MetalResponse>(gem);
        }

        public async Task UpdateAsync(Guid id, UpdateMetalRequest updateModel)
        {
            var gem = (await _materialRepository.GetAsync(c => c.MaterialId == id)).FirstOrDefault();
            if (gem != null)
            {
                var updateGem = _mapper.Map(updateModel, gem);
                await _materialRepository.UpdateAsync(updateGem);
            }
            else
            {
                throw new KeyNotFoundException("Metal not found.");
            }
        }
    }
}
