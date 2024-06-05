using AutoMapper;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;

namespace JewelryShop.BusinessLayer.Services
{
    public class JewelryService : IJewelryService
    {
        private readonly IJewelryRepository _jewelryRepository;
        private readonly IJewelryMaterialRepository _jewelryMaterialRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public JewelryService(IJewelryRepository jewelryRepository
                                , IJewelryMaterialRepository jewelryMaterialRepository
                                , IMaterialRepository materialRepository
                                , IMapper mapper)
        {
            _materialRepository = materialRepository;
            _jewelryRepository = jewelryRepository;
            _jewelryMaterialRepository = jewelryMaterialRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(JewelryDTO createModel)
        {
            Jewelry jewelry = _mapper.Map<Jewelry>(createModel);
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

        public async Task<IEnumerable<JewelryDTO>> GetAllAsync()
        {
            var jewelries = await _jewelryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<JewelryDTO>>(jewelries.ToList());
        }

        public async Task<JewelryDTO> GetByIdAsync(Guid id)
        {
            var jewelry = (await _jewelryRepository.GetAsync(j => j.JewelryId == id)).FirstOrDefault();
            return _mapper.Map<JewelryDTO>(jewelry);
        }

        public async Task UpdateAsync(Guid id, JewelryDTO updateModel)
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
