using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Guid> CreateAsync(OrderDetailDTO createModel)
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

        public async Task<IEnumerable<OrderDetailDTO>> GetAllAsync()
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDetailDTO>>(orderDetails.ToList());
        }

        public async Task<OrderDetailDTO> GetByIdAsync(Guid id)
        {
            var orderDetail = (await _orderDetailRepository.GetAsync(od => od.OrderDetailId == id)).FirstOrDefault();
            return _mapper.Map<OrderDetailDTO>(orderDetail);
        }

        public async Task UpdateAsync(Guid id, OrderDetailDTO updateModel)
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
