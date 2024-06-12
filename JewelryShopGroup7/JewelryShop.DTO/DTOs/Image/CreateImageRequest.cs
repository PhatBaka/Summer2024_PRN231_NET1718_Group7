using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs.Image
{
    public class CreateImageRequest
    {
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
