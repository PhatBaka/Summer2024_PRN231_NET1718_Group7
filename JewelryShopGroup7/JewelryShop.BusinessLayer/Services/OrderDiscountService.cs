using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;

namespace JewelryShop.BusinessLayer.Services
{
    public class OrderDiscountService : IOrderDiscountService
    {
        private readonly IOrderDiscountRepository _orderDiscountRepository;
        private readonly IMapper _mapper;

        public OrderDiscountService(IOrderDiscountRepository orderDiscountRepository, IMapper mapper)
        {
            _orderDiscountRepository = orderDiscountRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(OrderDiscountDTO createModel)
        {
            OrderDiscount orderDiscount = _mapper.Map<OrderDiscount>(createModel);
            return await _orderDiscountRepository.AddAsync(orderDiscount);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var orderDiscount = (await _orderDiscountRepository.GetAsync(od => od.OrderDiscountId == id)).FirstOrDefault();
                if (orderDiscount != null)
                {
                    await _orderDiscountRepository.RemoveAsync(orderDiscount);
                }
                else
                {
                    throw new KeyNotFoundException("Order Discount not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<OrderDiscountDTO>> GetAllAsync()
        {
            var orderDiscounts = await _orderDiscountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDiscountDTO>>(orderDiscounts.ToList());
        }

        public async Task<OrderDiscountDTO> GetByIdAsync(Guid id)
        {
            var orderDiscount = (await _orderDiscountRepository.GetAsync(od => od.OrderDiscountId == id)).FirstOrDefault();
            return _mapper.Map<OrderDiscountDTO>(orderDiscount);
        }

        public async Task UpdateAsync(Guid id, OrderDiscountDTO updateModel)
        {
            var orderDiscount = (await _orderDiscountRepository.GetAsync(od => od.OrderDiscountId == id)).FirstOrDefault();
            if (orderDiscount != null)
            {
                var updateOrderDiscount = _mapper.Map(updateModel, orderDiscount);
                await _orderDiscountRepository.UpdateAsync(updateOrderDiscount);
            }
            else
            {
                throw new KeyNotFoundException("Order Discount not found.");
            }
        }
    }
}
