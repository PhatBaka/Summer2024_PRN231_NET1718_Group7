using JewelryShop.DTO.DTOs;
using JewelryShop.DTO.DTOs.Image;

namespace JewelryShop.BusinessLayer.Interfaces
{
    public interface IImageService : IService<ImageResponse,CreateImageRequest,UpdateImageRequest,ImageFilter>
    {
    }
}
