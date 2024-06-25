using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Order;

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

        public async Task<Guid> CreateAsync(CreateOrderRequest createModel)
        {
            // cho nay tam code au
            Order order = _mapper.Map<Order>(createModel);
            foreach (var entity in order.OrderDetails)
            {
                entity.Jewelry = null;
            }
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

        public async Task<IEnumerable<OrderResponse>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderResponse>>(orders.ToList());
        }

        public async Task<OrderResponse> GetByIdAsync(Guid id)
        {
            var order = (await _orderRepository.GetAsync(o => o.OrderId == id)).FirstOrDefault();
            return _mapper.Map<OrderResponse>(order);
        }

        public async Task UpdateAsync(Guid id, UpdateOrderRequest updateModel)
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
