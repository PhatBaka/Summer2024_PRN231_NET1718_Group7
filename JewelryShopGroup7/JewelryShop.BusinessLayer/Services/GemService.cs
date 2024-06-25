using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs.Customer;
using JewelryShop.DTO.DTOs.Material.Gem;
using JewelryShop.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.BusinessLayer.Services
{
    public class GemService : IGemService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GemService(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateGemRequest createModel)
        {
            Material material = _mapper.Map<Material>(createModel);
            material.SellPrice = createModel.SellPrice;
            material.BuyPrice = createModel.SellPrice * 70 / 100;
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
                    throw new KeyNotFoundException("Gem not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<GemResponse>> GetAllAsync()
        {
            var gems = await _materialRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GemResponse>>(gems.ToList());
        }

        public async Task<GemResponse> GetByIdAsync(Guid id)
        {
            var gem = (await _materialRepository.GetAsync(c => c.MaterialId == id)).FirstOrDefault();
            return _mapper.Map<GemResponse>(gem);
        }

        public async Task UpdateAsync(Guid id, UpdateGemRequest updateModel)
        {
            var gem = (await _materialRepository.GetAsync(c => c.MaterialId == id)).FirstOrDefault();
            if (gem != null)
            {
                var updateGem = _mapper.Map(updateModel, gem);
                await _materialRepository.UpdateAsync(updateGem);
            }
            else
            {
                throw new KeyNotFoundException("Gem not found.");
            }
        }
    }
}
