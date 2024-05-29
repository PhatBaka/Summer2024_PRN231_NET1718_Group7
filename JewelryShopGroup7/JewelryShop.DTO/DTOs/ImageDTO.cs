using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs
{
	public class ImageDTO
	{
		public Guid ImageId { get; set; }

		public IFormFile ImageData { get; set; }
	}

	public class CreateImageDTO 
	{
		[Required]
		public IFormFile ImageData { get; set; }
	}

	public class UpdateImageDTO
	{
		public IFormFile ImageData { get; set; }
	}
}
