using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;

namespace JewelryShop.BusinessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(OrderDTO createModel)
        {
            Order order = _mapper.Map<Order>(createModel);
            return await _orderRepository.AddAsync(order);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var order = (await _orderRepository.GetAsync(o => o.OrderId == id)).FirstOrDefault();
                if (order != null)
                {
                    await _orderRepository.RemoveAsync(order);
                }
                else
                {
                    throw new KeyNotFoundException("Order not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders.ToList());
        }

        public async Task<OrderDTO> GetByIdAsync(Guid id)
        {
            var order = (await _orderRepository.GetAsync(o => o.OrderId == id)).FirstOrDefault();
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task UpdateAsync(Guid id, OrderDTO updateModel)
        {
            var order = (await _orderRepository.GetAsync(o => o.OrderId == id)).FirstOrDefault();
            if (order != null)
            {
                var updateOrder = _mapper.Map(updateModel, order);
                await _orderRepository.UpdateAsync(updateOrder);
            }
            else
            {
                throw new KeyNotFoundException("Order not found.");
            }
        }
    }
}
