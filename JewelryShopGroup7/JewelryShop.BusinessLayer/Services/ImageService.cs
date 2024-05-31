using AutoMapper;
using JewelryShop.BusinessLayer.Helpers;
using JewelryShop.BusinessLayer.Interfaces;
using JewelryShop.DAL.Models;
using JewelryShop.DAL.Repositories.Interface;
using JewelryShop.DAL.Repositories.Interfaces;
using JewelryShop.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public async Task<Guid> CreateAsync(ImageDTO createModel)
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

		public async Task<IEnumerable<ImageDTO>> GetAllAsync()
		{
			var images = await _imageRepository.GetAllAsync();
			return _mapper.Map<IEnumerable<ImageDTO>>(images.ToList());
		}

		public async Task<ImageDTO> GetByIdAsync(Guid id)
		{
			var image = (await _imageRepository.GetAsync(g => g.ImageId == id)).FirstOrDefault();
			return _mapper.Map<ImageDTO>(image);
		}

		public async Task UpdateAsync(Guid id, ImageDTO updateModel)
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