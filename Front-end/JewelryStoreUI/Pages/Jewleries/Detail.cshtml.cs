using JewelryStoreUI.DTOs.Gems;
using JewelryStoreUI.DTOs.Jewelries;
using JewelryStoreUI.Enums;
using JewelryStoreUI.Pages.DTOs.Jewelry;
using JewelryStoreUI.Pages.DTOs.Material;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Jewleries
{
    public class DetailModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DetailModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            JewelryCategory = Enum.GetValues(typeof(JewelryCategory))
                                 .Cast<JewelryCategory>()
                                 .Select(e => new SelectListItem
                                 {
                                     Value = ((int)e).ToString(),
                                     Text = e.ToString()
                                 }).ToList();
        }

        public JewelryResponse Jewelry { get; set; }
        public List<SelectListItem>? JewelryCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5233/odata/JewelryOData/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Jewelry = JsonConvert.DeserializeObject<JewelryResponse>(content);
                return Page();
            }
            else
            {
                // Handle error response
                return NotFound();
            }
        }
    }
}
