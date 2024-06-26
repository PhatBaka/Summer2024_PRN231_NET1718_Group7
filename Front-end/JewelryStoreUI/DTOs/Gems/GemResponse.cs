using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JewelryStoreUI.DTOs.JewelryMaterials;
using System.Text.Json.Serialization;

namespace JewelryStoreUI.DTOs.Gems
{
	public class GemOData
	{
		[JsonPropertyName("@odata.context")]
		public string? Context { get; set; }

		[JsonPropertyName("value")]
		public List<GemResponse>? GemResponse { get; set; }

		[JsonPropertyName("@odata.count")]
		public int Count { get; set; }
	}

	public class GemResponse
    {
        public Guid MaterialId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal SellPrice { get; set; }

        public decimal BuyPrice { get; set; }

        public byte[]? MaterialImageData { get; set; }

        public byte[]? CertificateImageData { get; set; }

        public bool IsMetal { get; set; }

        public decimal Weight { get; set; }

        public decimal Purity { get; set; }

        public string? Clarity { get; set; }

        public string? Color { get; set; }

        public string? Sharp { get; set; }

        public virtual ICollection<JewelryMaterialResponse> JewelryMaterials { get; set; } = new List<JewelryMaterialResponse>();

        // public virtual ICollection<MaterialPrice> MaterialPrices { get; set; } = new List<MaterialPrice>();
    }
}
