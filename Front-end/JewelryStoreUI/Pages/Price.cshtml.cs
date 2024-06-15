using JewelryStoreUI.Helpers;
using JewelryStoreUI.Pages.DTOs.Material;
using JewelryStoreUI.Pages.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages
{
    public class PriceModel : PageModel
    {
		public IList<MaterialDTO> Materials = new List<MaterialDTO>();
		private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
		private string materialUrl { get; set; }
		private string imageUrl { get; set; }

		public PriceModel()
		{
			materialUrl = $"{url}Material";
			imageUrl = $"{url}Image/";
		}

		public async Task OnGetAsync()
        {
			using (var client = new HttpClient())
			{
				var response = await client.GetAsync(materialUrl);
				var result = await response.Content.ReadAsStringAsync();
				var entity = JsonConvert.DeserializeObject<IList<dynamic>>(result);
				foreach (var item in entity)
				{
					Materials.Add(new()
					{
						Base64 = await Utils.GetImageAsync($"{imageUrl}{item.imageId}"),
						Data = item,
					});
				}
			}
		}
    }
}
