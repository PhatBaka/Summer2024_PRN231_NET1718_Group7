using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.StoreDiscount;

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

        public async Task<Guid> CreateAsync(CreateStoreDiscountRequest createModel)
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

        public async Task<IEnumerable<StoreDiscountResponse>> GetAllAsync()
        {
            var storeDiscounts = await _storeDiscountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StoreDiscountResponse>>(storeDiscounts.ToList());
        }

        public async Task<StoreDiscountResponse> GetByIdAsync(Guid id)
        {
            var storeDiscount = (await _storeDiscountRepository.GetAsync(sd => sd.StoreDiscountId == id)).FirstOrDefault();
            if (storeDiscount != null)
            {
                await _storeDiscountRepository.LoadRelate(storeDiscount);
            }
            return _mapper.Map<StoreDiscountResponse>(storeDiscount);
        }

        public async Task UpdateAsync(Guid id, UpdateStoreDiscountRequest updateModel)
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
