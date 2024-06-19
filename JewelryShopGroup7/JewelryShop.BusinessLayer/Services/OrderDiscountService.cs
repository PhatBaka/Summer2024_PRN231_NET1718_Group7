using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.OrderDiscount;
using Microsoft.IdentityModel.Tokens;

namespace JewelryShop.BusinessLayer.Services
{
    public class OrderDiscountService : IOrderDiscountService
    {
        private readonly IOrderDiscountRepository _orderDiscountRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IStoreDiscountRepository _storeDiscountRepository;
        private readonly ITierRepository _tierRepository;
        private readonly IMapper _mapper;

        public OrderDiscountService(IOrderDiscountRepository orderDiscountRepository, IMapper mapper,IOfferRepository offerRepository, IStoreDiscountRepository storeDiscountRepository, ITierRepository tierRepository)
        {
            _orderDiscountRepository = orderDiscountRepository;
            _mapper = mapper;
            _offerRepository = offerRepository;
            _storeDiscountRepository = storeDiscountRepository;
            _tierRepository = tierRepository;
        }

        public async Task<Guid> CreateAsync(CreateOrderDiscountRequest createModel)
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

        public async Task<IEnumerable<OrderDiscountResponse>> GetAllAsync()
        {
            var orderDiscounts = await _orderDiscountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDiscountResponse>>(orderDiscounts.ToList());
        }

        public async Task<OrderDiscountResponse> GetByIdAsync(Guid id)
        {
            var orderDiscount = (await _orderDiscountRepository.GetAsync(od => od.OrderDiscountId == id)).FirstOrDefault();
            return _mapper.Map<OrderDiscountResponse>(orderDiscount);
        }

        public async Task UpdateAsync(Guid id, UpdateOrderDiscountRequest updateModel)
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

        public Task<Guid> UpdateDiscount(string? tiername, string? OrderDiscountCode, decimal? offerPercent, decimal? total)
        {
            var offerdis = _offerRepository.GetFirstOrDefaultAsync(of => of.OfferPercent == offerPercent);
            var orderdis = _storeDiscountRepository.GetFirstOrDefaultAsync(sd => sd.DiscountCode == OrderDiscountCode);
            var tierdis = _tierRepository.GetFirstOrDefaultAsync(ti => ti.TierName == tiername);

            CreateOrderDiscountRequest createOrderDiscountRequest = new CreateOrderDiscountRequest();

            createOrderDiscountRequest.OfferId = offerdis.Result.OfferId != null ? offerdis.Result.OfferId : (Guid?)null;
            createOrderDiscountRequest.StoreDiscountId = orderdis.Result.StoreDiscountId != null ? orderdis.Result.StoreDiscountId : (Guid?)null;
            createOrderDiscountRequest.TierId = tierdis.Result.TierId != null ? tierdis.Result.TierId : (Guid?)null;

            

            var offerdisprice = offerdis.Result.OfferPercent ?? 0;
            var orderdisprice = orderdis.Result.DiscountAmount ?? 0;
            var tierdisprice = tierdis.Result.DiscountPercentage ?? 0;

            if (total.HasValue)
            {
                createOrderDiscountRequest.Value = (total.Value * orderdisprice / 100) + (total.Value * offerdisprice / 100) + (total.Value * tierdisprice / 100);
            }

            var id = CreateAsync(createOrderDiscountRequest);

            return id ;
        }
        public Task<decimal?> UpdateTotalPriceaddOff(decimal offerPercent, decimal? total) {
            var offer = _offerRepository.GetFirstOrDefaultAsync(off => off.OfferPercent == offerPercent);
            if (offer.Result.ApprovedBy == null)
            {
                throw new NotImplementedException("The discount not have permittion");
            }
            else {
                var offerdisprice = offer.Result.OfferPercent ?? 0;
                decimal? result = ((total * offerdisprice) / 100);
                return Task.FromResult(result);
            }
            
        }

        public Task<decimal?> UpdateTotalPriceaddStoreCode(string? Code, decimal? total)
        {
            try
            {
                var orderdis = _storeDiscountRepository.GetFirstOrDefaultAsync(sd => sd.DiscountCode == Code);
                var orderdisprice = orderdis.Result.DiscountAmount ?? 0;
                return Task.FromResult((total * orderdisprice) / 100);

            }catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public Task<decimal?> UpdateTotalPriceaddTier(string? tier, decimal? total)
        {
            try
            {
                var TierDis = _tierRepository.GetFirstOrDefaultAsync(sd => sd.TierName == tier);
                var TierDisPrice = TierDis.Result.DiscountPercentage ?? 0;
                return Task.FromResult((total * TierDisPrice) / 100);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
