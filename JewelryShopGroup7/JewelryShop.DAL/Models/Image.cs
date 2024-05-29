using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryShop.DAL.Models
{
	[Table("Image")]
	public class Image
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ImageId { get; set; }

		[Required]
		public byte[] ImageData { get; set; }

		public virtual ICollection<Jewelry> Jewelries { get; set; } = new List<Jewelry>();

		public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
	}
}
