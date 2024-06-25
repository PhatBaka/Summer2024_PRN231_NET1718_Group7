using JewelryStoreUI.Models.DTOs.Metals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.IO;
using JewelryStoreUI.Helpers;

namespace JewelryStoreUI.Pages
{
    public class PriceModel : PageModel
    {
        public IList<MetalDTO> MetalDTOs = new List<MetalDTO>();
        private IConfiguration Configuration { get; set; }
        public string? UpdatedDate { get; set; }

        public PriceModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void OnGetAsync()
        {
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
            var gold = JsonSerializer.Deserialize<MetalDTO>(Utils.ReadJsonFile("gold.json"), options);
            var silver = JsonSerializer.Deserialize<MetalDTO>(Utils.ReadJsonFile("silver.json"), options);
            var palladium = JsonSerializer.Deserialize<MetalDTO>(Utils.ReadJsonFile("palladium.json"), options);
            if (gold != null && silver != null && palladium != null)
            {
                MetalDTOs.Add(gold);
                MetalDTOs.Add(silver);
                MetalDTOs.Add(palladium);
            }
            UpdatedDate = gold.Timestamp.ToString();
        }
    }
}
