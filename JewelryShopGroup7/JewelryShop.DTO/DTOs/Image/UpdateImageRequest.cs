using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Image
{
    public class UpdateImageRequest
    {
        public IFormFile ImageData { get; set; }
    }
}
