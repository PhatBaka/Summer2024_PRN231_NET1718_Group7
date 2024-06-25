using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.OrderDetail;

namespace JewelryShop.BusinessLayer.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateOrderDetailRequest createModel)
        {
            OrderDetail orderDetail = _mapper.Map<OrderDetail>(createModel);
            return await _orderDetailRepository.AddAsync(orderDetail);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var orderDetail = (await _orderDetailRepository.GetAsync(od => od.OrderDetailId == id)).FirstOrDefault();
                if (orderDetail != null)
                {
                    await _orderDetailRepository.RemoveAsync(orderDetail);
                }
                else
                {
                    throw new KeyNotFoundException("Order Detail not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<OrderDetailResponse>> GetAllAsync()
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDetailResponse>>(orderDetails.ToList());
        }

        public async Task<OrderDetailResponse> GetByIdAsync(Guid id)
        {
            var orderDetail = (await _orderDetailRepository.GetAsync(od => od.OrderDetailId == id)).FirstOrDefault();
            return _mapper.Map<OrderDetailResponse>(orderDetail);
        }

        public async Task UpdateAsync(Guid id, UpdateOrderDetailRequest updateModel)
        {
            var orderDetail = (await _orderDetailRepository.GetAsync(od => od.OrderDetailId == id)).FirstOrDefault();
            if (orderDetail != null)
            {
                var updateOrderDetail = _mapper.Map(updateModel, orderDetail);
                await _orderDetailRepository.UpdateAsync(updateOrderDetail);
            }
            else
            {
                throw new KeyNotFoundException("Order Detail not found.");
            }
        }

    }
}
