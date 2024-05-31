using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JewleryShop.MetalPrice.Models
{
	[Table("Metal")]
	public class Metal
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int MetalId { get; set; }

		[Required]
		[StringLength(100)]
		public string MetalType { get; set; } // E.g., Gold, Silver, Platinum, etc.

		[Required]
		public double Purity { get; set; } // Purity in karats for gold, or percentage for silver

		[Required]
		public double Weight { get; set; } // Weight of the metal in grams or other suitable unit

		[Required]
		public decimal Price { get; set; } // Price per gram or per unit weight
	}
}
