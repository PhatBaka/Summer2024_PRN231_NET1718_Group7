using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;

namespace JewelryShop.BusinessLayer.Services
{
    public class StoreDiscountService : IStoreDiscountService
    {
        private readonly IStoreDiscountRepository _storeDiscountRepository;
        private readonly IMapper _mapper;

        public StoreDiscountService(IStoreDiscountRepository storeDiscountRepository, IMapper mapper)
        {
            _storeDiscountRepository = storeDiscountRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(StoreDiscountDTO createModel)
        {
            StoreDiscount storeDiscount = _mapper.Map<StoreDiscount>(createModel);
            return await _storeDiscountRepository.AddAsync(storeDiscount);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var storeDiscount = (await _storeDiscountRepository.GetAsync(sd => sd.StoreDiscountId == id)).FirstOrDefault();
                if (storeDiscount != null)
                {
                    await _storeDiscountRepository.RemoveAsync(storeDiscount);
                }
                else
                {
                    throw new KeyNotFoundException("Store Discount not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<StoreDiscountDTO>> GetAllAsync()
        {
            var storeDiscounts = await _storeDiscountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StoreDiscountDTO>>(storeDiscounts.ToList());
        }

        public async Task<StoreDiscountDTO> GetByIdAsync(Guid id)
        {
            var storeDiscount = (await _storeDiscountRepository.GetAsync(sd => sd.StoreDiscountId == id)).FirstOrDefault();
            return _mapper.Map<StoreDiscountDTO>(storeDiscount);
        }

        public async Task UpdateAsync(Guid id, StoreDiscountDTO updateModel)
        {
            var storeDiscount = (await _storeDiscountRepository.GetAsync(sd => sd.StoreDiscountId == id)).FirstOrDefault();
            if (storeDiscount != null)
            {
                var updateStoreDiscount = _mapper.Map(updateModel, storeDiscount);
                await _storeDiscountRepository.UpdateAsync(updateStoreDiscount);
            }
            else
            {
                throw new KeyNotFoundException("Store Discount not found.");
            }
        }
    }
}
