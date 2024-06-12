using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Image
{
    public class ImageResponse
    {
        public Guid ImageId { get; set; }
        public byte[] ImageData { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
