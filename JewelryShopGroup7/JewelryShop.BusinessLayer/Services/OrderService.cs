﻿using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Order;
using JewelryShop.DTO.Enums;

namespace JewelryShop.BusinessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IJewelryRepository _jewelryRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, 
                            IJewelryRepository jewelryRepository,
                            ICustomerRepository customerRepository,
                            IAccountRepository accountRepository,
                            IMapper mapper)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
            _jewelryRepository = jewelryRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateOrderRequest createModel)
        {
            decimal totalPrice = 0, discountPrice = 0, finalPrice = 0;
            foreach (var orderDetail in createModel.OrderDetails)
            {
                var jewelry = _jewelryRepository.GetFirstOrDefaultAsync(x => x.JewelryId == orderDetail.JewelryId).Result;
                // giá một sản phầm
                orderDetail.UnitPrice = jewelry.UnitPrice;
                // giá tính cả số lượng
                orderDetail.TotalPrice = jewelry.UnitPrice;
                // giá chiết khấu

                // giá cuối cùng 
                orderDetail.FinalPrice = jewelry.UnitPrice;
                

                totalPrice += jewelry.UnitPrice;
                discountPrice += jewelry.UnitPrice;
                finalPrice += jewelry.UnitPrice;
            }
            Order order = _mapper.Map<Order>(createModel);
            order.AccountId = _accountRepository.GetFirstOrDefaultAsync(x => x.AccountId == createModel.AccountId).Result.AccountId;
            order.CustomerId = _customerRepository.GetFirstOrDefaultAsync(x => x.PhoneNumber == createModel.PhoneNumber).Result.CustomerId;
            order.OrderDate = DateTime.Now;
            order.Status = OrderStatus.DONE.ToString();
            order.FinalPrice = finalPrice;
            order.DiscountPrice = discountPrice;
            order.TotalPrice = totalPrice;
            foreach (var jewelry in createModel.OrderDetails)
            {
                var dbJewlry = _jewelryRepository.GetFirstOrDefaultAsync(x => x.JewelryId.Equals(jewelry.JewelryId));
                if (dbJewlry != null)
                {
                    if(jewelry.Quantity > dbJewlry.Result.Quantity)
                    {
                        throw new ArgumentException("Số lượng không phù hợp");
                    }
                }
            }
            foreach (var jewelry in createModel.OrderDetails)
            {
                var dbJewlry = _jewelryRepository.GetFirstOrDefaultAsync(x => x.JewelryId.Equals(jewelry.JewelryId));
                if (dbJewlry != null)
                {
                        dbJewlry.Result.Quantity -= jewelry.Quantity;
                        await _jewelryRepository.UpdateAsync(dbJewlry.Result);
                }
            }
            var orderId = await _orderRepository.AddAsync(order);
            return orderId;
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
