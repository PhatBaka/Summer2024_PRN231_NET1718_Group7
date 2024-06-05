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
    public class OrderTypeService : IOrderTypeService
    {
        private readonly IOrderTypeRepository _orderTypeRepository;
        private readonly IMapper _mapper;

        public OrderTypeService(IOrderTypeRepository orderTypeRepository, IMapper mapper)
        {
            _orderTypeRepository = orderTypeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(OrderTypeDTO createModel)
        {
            OrderType orderType = _mapper.Map<OrderType>(createModel);
            return await _orderTypeRepository.AddAsync(orderType);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var orderType = (await _orderTypeRepository.GetAsync(ot => ot.OrderTypeId == id)).FirstOrDefault();
                if (orderType != null)
                {
                    await _orderTypeRepository.RemoveAsync(orderType);
                }
                else
                {
                    throw new KeyNotFoundException("Order Type not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<OrderTypeDTO>> GetAllAsync()
        {
            var orderTypes = await _orderTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderTypeDTO>>(orderTypes.ToList());
        }

        public async Task<OrderTypeDTO> GetByIdAsync(Guid id)
        {
            var orderType = (await _orderTypeRepository.GetAsync(ot => ot.OrderTypeId == id)).FirstOrDefault();
            return _mapper.Map<OrderTypeDTO>(orderType);
        }

        public async Task UpdateAsync(Guid id, OrderTypeDTO updateModel)
        {
            var orderType = (await _orderTypeRepository.GetAsync(ot => ot.OrderTypeId == id)).FirstOrDefault();
            if (orderType != null)
            {
                var updateOrderType = _mapper.Map(updateModel, orderType);
                await _orderTypeRepository.UpdateAsync(updateOrderType);
            }
            else
            {
                throw new KeyNotFoundException("Order Type not found.");
            }
        }
    }
}
