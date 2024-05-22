using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interface;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryShop.BusinessLayer.Services
{
    public class TierService : ITierService
    {
        private readonly ITierRepository _tierRepository;
        private readonly IMapper _mapper;

        public TierService(ITierRepository tierRepository, IMapper mapper)
        {
            _tierRepository = tierRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(TierDTO createModel)
        {
            Tier tier = _mapper.Map<Tier>(createModel);
            return await _tierRepository.AddAsync(tier);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var tier = (await _tierRepository.GetAsync(t => t.TierId == id)).FirstOrDefault();
                if (tier != null)
                {
                    await _tierRepository.RemoveAsync(tier);
                }
                else
                {
                    throw new KeyNotFoundException("Tier not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TierDTO>> GetAllAsync()
        {
            var tiers = await _tierRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TierDTO>>(tiers.ToList());
        }

        public async Task<TierDTO> GetByIdAsync(Guid id)
        {
            var tier = (await _tierRepository.GetAsync(t => t.TierId == id)).FirstOrDefault();
            return _mapper.Map<TierDTO>(tier);
        }

        public async Task UpdateAsync(Guid id, TierDTO updateModel)
        {
            var tier = (await _tierRepository.GetAsync(t => t.TierId == id)).FirstOrDefault();
            if (tier != null)
            {
                var updateTier = _mapper.Map(updateModel, tier);
                await _tierRepository.UpdateAsync(updateTier);
            }
            else
            {
                throw new KeyNotFoundException("Tier not found.");
            }
        }
    }
}
