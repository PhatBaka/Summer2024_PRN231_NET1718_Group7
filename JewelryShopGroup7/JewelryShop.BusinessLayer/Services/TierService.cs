using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Tier;

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

        public async Task<Guid> CreateAsync(CreateTierRequest createModel)
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

        public async Task<IEnumerable<TierResponse>> GetAllAsync()
        {
            var tiers = await _tierRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TierResponse>>(tiers.ToList());
        }

        public async Task<TierResponse> GetByIdAsync(Guid id)
        {
            var tier = (await _tierRepository.GetAsync(t => t.TierId == id)).FirstOrDefault();
            return _mapper.Map<TierResponse>(tier);
        }

        public async Task UpdateAsync(Guid id, UpdateTierRequest updateModel)
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
