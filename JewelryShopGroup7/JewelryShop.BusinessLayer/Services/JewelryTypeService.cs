//using AutoMapper;
//using JewelryShop.BusinessLayer.Interfaces;
//using JewelryShop.DAL.Models;
//using JewelryShop.DAL.Repositories.Implement;
//using JewelryShop.DAL.Repositories.Interface;
//using JewelryShop.DTO.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace JewelryShop.BusinessLayer.Services
//{
//    public class JewelryTypeService : IJewelryTypeService
//    {
//        private readonly IJewelryTypeRepository _jewelryTypeRepository;
//        private readonly IMapper _mapper;

//        public JewelryTypeService(IJewelryTypeRepository jewelryTypeRepository, IMapper mapper)
//        {
//            _jewelryTypeRepository = jewelryTypeRepository;
//            _mapper = mapper;
//        }

//        public async Task<Guid> CreateAsync(JewelryTypeDTO createModel)
//        {
//            JewelryType jewelryType = _mapper.Map<JewelryType>(createModel);
//            return await _jewelryTypeRepository.AddAsync(jewelryType);
//        }

//        public async Task DeleteAsync(Guid id)
//        {
//            try
//            {
//                var jewelryType = (await _jewelryTypeRepository.GetAsync(jt => jt.TypeId == id)).FirstOrDefault();
//                if (jewelryType != null)
//                {
//                    await _jewelryTypeRepository.RemoveAsync(jewelryType);
//                }
//                else
//                {
//                    throw new KeyNotFoundException("Jewelry Type not found.");
//                }
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<IEnumerable<JewelryTypeDTO>> GetAllAsync()
//        {
//            var jewelryTypes = await _jewelryTypeRepository.GetAllAsync();
//            return _mapper.Map<IEnumerable<JewelryTypeDTO>>(jewelryTypes.ToList());
//        }

//        public async Task<JewelryTypeDTO> GetByIdAsync(Guid id)
//        {
//            var jewelryType = (await _jewelryTypeRepository.GetAsync(jt => jt.TypeId == id)).FirstOrDefault();
//            return _mapper.Map<JewelryTypeDTO>(jewelryType);
//        }

//        public async Task UpdateAsync(Guid id, JewelryTypeDTO updateModel)
//        {
//            var jewelryType = (await _jewelryTypeRepository.GetAsync(jt => jt.TypeId == id)).FirstOrDefault();
//            if (jewelryType != null)
//            {
//                var updateJewelryType = _mapper.Map(updateModel, jewelryType);
//                await _jewelryTypeRepository.UpdateAsync(updateJewelryType);
//            }
//            else
//            {
//                throw new KeyNotFoundException("Jewelry Type not found.");
//            }
//        }
//    }
//}
