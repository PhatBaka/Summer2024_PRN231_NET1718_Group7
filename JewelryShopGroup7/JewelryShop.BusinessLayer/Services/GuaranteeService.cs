using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;

namespace JewelryShop.BusinessLayer.Services
{
    public class GuaranteeService : IGuaranteeService
    {
        private readonly IGuaranteeRepository _guaranteeRepository;
        private readonly IMapper _mapper;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public GuaranteeService(IGuaranteeRepository guaranteeRepository, IMapper mapper, IOrderDetailRepository orderDetailRepository)
        {
            _guaranteeRepository = guaranteeRepository;
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<Guid> CreateAsync(GuaranteeDTO createModel)
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

        public async Task<IEnumerable<GuaranteeDTO>> GetAllAsync()
        {
            var guarantees = await _guaranteeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GuaranteeDTO>>(guarantees.ToList());
        }

        public async Task<GuaranteeDTO> GetByIdAsync(Guid id)
        {
            var guarantee = (await _guaranteeRepository.GetAsync(g => g.GuaranteeId == id)).FirstOrDefault();
            return _mapper.Map<GuaranteeDTO>(guarantee);
        }

        public async Task UpdateAsync(Guid id, GuaranteeDTO updateModel)
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
        public async Task CreateofOrderAsync(GuaranteeDTO createModel, Guid id)
        {
            Guarantee guarantee = _mapper.Map<Guarantee>(createModel);
            var order = (await _orderDetailRepository.GetAsync(or => or.OrderDetailId == id)).FirstOrDefault();
            order.Guarantees.Add(guarantee);
            await _orderDetailRepository.UpdateAsync(order);
        }
    }
}
