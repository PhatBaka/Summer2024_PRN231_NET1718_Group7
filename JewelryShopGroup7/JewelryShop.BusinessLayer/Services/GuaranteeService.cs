using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Guarantee;

namespace JewelryShop.BusinessLayer.Services
{
    public class GuaranteeService : IGuaranteeService
    {
        private readonly IGuaranteeRepository _guaranteeRepository;
        private readonly IMapper _mapper;

        public GuaranteeService(IGuaranteeRepository guaranteeRepository, IMapper mapper)
        {
            _guaranteeRepository = guaranteeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateGuaranteeRequest createModel)
        {
            Guarantee guarantee = _mapper.Map<Guarantee>(createModel);
            return await _guaranteeRepository.AddAsync(guarantee);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var guarantee = (await _guaranteeRepository.GetAsync(g => g.GuaranteeId == id)).FirstOrDefault();
                if (guarantee != null)
                {
                    await _guaranteeRepository.RemoveAsync(guarantee);
                }
                else
                {
                    throw new KeyNotFoundException("Guarantee not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<GuaranteeResponse>> GetAllAsync()
        {
            var guarantees = await _guaranteeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GuaranteeResponse>>(guarantees.ToList());
        }

        public async Task<GuaranteeResponse> GetByIdAsync(Guid id)
        {
            var guarantee = (await _guaranteeRepository.GetAsync(g => g.GuaranteeId == id)).FirstOrDefault();
            return _mapper.Map<GuaranteeResponse>(guarantee);
        }

        public async Task UpdateAsync(Guid id, UpdateGuaranteeRequest updateModel)
        {
            var guarantee = (await _guaranteeRepository.GetAsync(g => g.GuaranteeId == id)).FirstOrDefault();
            if (guarantee != null)
            {
                var updateGuarantee = _mapper.Map(updateModel, guarantee);
                await _guaranteeRepository.UpdateAsync(updateGuarantee);
            }
            else
            {
                throw new KeyNotFoundException("Guarantee not found.");
            }
        }
    }
}
