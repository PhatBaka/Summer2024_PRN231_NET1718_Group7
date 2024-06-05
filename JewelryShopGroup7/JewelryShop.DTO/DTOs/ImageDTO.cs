using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace JewelryShop.DTO.DTOs
{
    public class ImageDTO
    {
        public Guid ImageId { get; set; }
        public byte[] ImageData { get; set; }
        public IFormFile ImageFile { get; set; }
    }

    public class CreateImageDTO
    {
        [Required]
        public IFormFile ImageFile { get; set; }
    }

    public class UpdateImageDTO
    {
        public IFormFile ImageData { get; set; }
    }

    public class GetImageDTO
    {
        public Guid ImageId { get; set; }
    }
}
