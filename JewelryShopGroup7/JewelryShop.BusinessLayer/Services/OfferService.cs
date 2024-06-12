using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Offer;

namespace JewelryShop.BusinessLayer.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public OfferService(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateOfferRequest createModel)
        {
            Offer offer = _mapper.Map<Offer>(createModel);
            return await _offerRepository.AddAsync(offer);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var offer = (await _offerRepository.GetAsync(o => o.OfferId == id)).FirstOrDefault();
                if (offer != null)
                {
                    await _offerRepository.RemoveAsync(offer);
                }
                else
                {
                    throw new KeyNotFoundException("Offer not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<OfferResponse>> GetAllAsync()
        {
            var offers = await _offerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OfferResponse>>(offers.ToList());
        }

        public async Task<OfferResponse> GetByIdAsync(Guid id)
        {
            var offer = (await _offerRepository.GetAsync(o => o.OfferId == id)).FirstOrDefault();
            return _mapper.Map<OfferResponse>(offer);
        }

        public async Task UpdateAsync(Guid id, UpdateOffterRequest updateModel)
        {
            var offer = (await _offerRepository.GetAsync(o => o.OfferId == id)).FirstOrDefault();
            if (offer != null)
            {
                var updateOffer = _mapper.Map(updateModel, offer);
                await _offerRepository.UpdateAsync(updateOffer);
            }
            else
            {
                throw new KeyNotFoundException("Offer not found.");
            }
        }
    }
}
