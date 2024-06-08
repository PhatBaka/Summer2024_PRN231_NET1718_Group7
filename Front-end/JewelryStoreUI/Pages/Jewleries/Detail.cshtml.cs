using JewelryStoreUI.Pages.DTOs.Jewelry;
using JewelryStoreUI.Pages.DTOs.Material;
using JewelryStoreUI.Pages.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Jewleries
{
    public class DetailModel : PageModel
    {
        [BindProperty]
        public JewelryDTO JewelryDTO { get; set; }
        public List<MaterialDTO> MaterialDTOs = new List<MaterialDTO>();
        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string jewelryUrl;
        private string imageUrl;

        public DetailModel()
        {
            jewelryUrl = url + "Jewelry/";
            imageUrl = url + "Image/"; 
        }

        public async Task<string> GetImageAsync(dynamic imageId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{imageUrl}{imageId}");
                var result = await response.Content.ReadAsStringAsync();
                var entity = JsonConvert.DeserializeObject<dynamic>(result);
                byte[] imageData = Convert.FromBase64String((string)entity.imageData);
                return Convert.ToBase64String(imageData);
            }
        }

        public async Task OnGetAsync(string id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{jewelryUrl}{id}");
                var result = await response.Content.ReadAsStringAsync();
                var entity = JsonConvert.DeserializeObject<dynamic>(result);
                JewelryDTO = new()
                {
                    Base64 = await GetImageAsync(entity.imageId),
                    Data = entity
                };
                foreach (var material in JewelryDTO.Data.jewelryMaterials)
                {
                    MaterialDTOs.Add(new()
                    {
                        Data = material,
                        Base64 = await GetImageAsync(material.material.imageId)
                    });
                }
            }
        }
    }
}
