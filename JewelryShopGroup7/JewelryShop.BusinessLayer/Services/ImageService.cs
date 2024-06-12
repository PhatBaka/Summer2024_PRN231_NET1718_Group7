using AutoMapper;
using JewelryShop.BusinessLayer.Helpers;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Image;

namespace JewelryShop.BusinessLayer.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateImageRequest createModel)
        {
            Image image = new()
            {
                ImageData = await FileHelper.ConvertToByteArrayAsync(createModel.ImageFile)
            };
            return await _imageRepository.AddAsync(image);
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var image = (await _imageRepository.GetAsync(g => g.ImageId == id)).FirstOrDefault();
                if (image != null)
                {
                    await _imageRepository.RemoveAsync(image);
                }
                else
                {
                    throw new KeyNotFoundException("Image not found.");
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ImageResponse>> GetAllAsync()
        {
            var images = await _imageRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ImageResponse>>(images.ToList());
        }

        public async Task<ImageResponse> GetByIdAsync(Guid id)
        {
            var image = (await _imageRepository.GetAsync(g => g.ImageId == id)).FirstOrDefault();
            return _mapper.Map<ImageResponse>(image);
        }

        public async Task UpdateAsync(Guid id, UpdateImageRequest updateModel)
        {
            var image = (await _imageRepository.GetAsync(g => g.ImageId == id)).FirstOrDefault();
            if (image != null)
            {
                var updateGuarantee = _mapper.Map(updateModel, image);
                await _imageRepository.UpdateAsync(updateGuarantee);
            }
            else
            {
                throw new KeyNotFoundException("Image not found.");
            }
        }
    }
}