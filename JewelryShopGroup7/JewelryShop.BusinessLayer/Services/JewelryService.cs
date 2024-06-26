using AutoMapper;
using JewelryShop.BusinessLayer.Helpers;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Jewelry;
using JewelryShop.DTO.Enums;

namespace JewelryShop.BusinessLayer.Services
{
    public class JewelryService : IJewelryService
    {
        private readonly IJewelryRepository _jewelryRepository;
        //private readonly IJewelryMaterialRepository _jewelryMaterialRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public JewelryService(IJewelryRepository jewelryRepository
                                //, IJewelryMaterialRepository jewelryMaterialRepository
                                , IMaterialRepository materialRepository
                                , IMapper mapper)
        {
            _materialRepository = materialRepository;
            _jewelryRepository = jewelryRepository;
            //_jewelryMaterialRepository = jewelryMaterialRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateJewelryRequest createModel)
        {
            decimal totalWeight = 0;
            Jewelry jewelry = _mapper.Map<Jewelry>(createModel);
            jewelry.Status = ObjectStatus.ACTIVE.ToString();
            foreach (var materialId in createModel.MaterialIds)
            {
                var material = await _materialRepository.GetFirstOrDefaultAsync(x => x.MaterialId == materialId);
                totalWeight += material.Weight;
                // nếu là kim loại thì nhân tiền bán ra với cân nặng
                if (material.IsMetal)
                {
                    jewelry.TotalMetalPrice += material.SellPrice;
                }
                else
                {
                    jewelry.TotalGemPrice = material.SellPrice;
                }
                jewelry.Materials.Add(material);
            }
            jewelry.MaterialPrice = jewelry.TotalMetalPrice + jewelry.TotalGemPrice;
            jewelry.TotalWeight = totalWeight;
            jewelry.UnitPrice = jewelry.MaterialPrice + createModel.ManufacturingFees;
            jewelry.CreatedDate = DateTime.Now;
            jewelry.JewelryImageData = await FileHelper.ConvertToByteArrayAsync(createModel.JewelryImageFile);
            return await _jewelryRepository.AddAsync(jewelry);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var jewelry = (await _jewelryRepository.GetAsync(j => j.JewelryId == id)).FirstOrDefault();
                if (jewelry != null)
                {
                    await _jewelryRepository.RemoveAsync(jewelry);
                }
                else
                {
                    throw new KeyNotFoundException("Jewelry not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<JewelryResponse>> GetAllAsync()
        {
            var jewelries = await _jewelryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<JewelryResponse>>(jewelries.ToList());
        }

        public async Task<JewelryResponse> GetByIdAsync(Guid id)
        {
            var jewelry = (await _jewelryRepository.GetAsync(j => j.JewelryId == id)).FirstOrDefault();
            return _mapper.Map<JewelryResponse>(jewelry);
        }

        public async Task UpdateAsync(Guid id, UpdateJewelryRequest updateModel)
        {
            var jewelry = (await _jewelryRepository.GetAsync(j => j.JewelryId == id)).FirstOrDefault();
            if (jewelry != null)
            {
                var updateJewelry = _mapper.Map(updateModel, jewelry);
                await _jewelryRepository.UpdateAsync(updateJewelry);
            }
            else
            {
                throw new KeyNotFoundException("Jewelry not found.");
            }
        }
    }
}
