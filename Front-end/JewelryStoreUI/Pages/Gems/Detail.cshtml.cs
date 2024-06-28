using JewelryStoreUI.DTOs.Gems;
using JewelryStoreUI.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Gems
{
    public class DetailModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DetailModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            ClarityOptions = Enum.GetValues(typeof(ClarityEnum))
                     .Cast<ClarityEnum>()
                     .Select(e => new SelectListItem
                     {
                         Value = ((int)e).ToString(),
                         Text = e.ToString()
                     }).ToList();
        }
        public List<SelectListItem>? ClarityOptions { get; set; }

        public GemResponse Gem { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5233/odata/GemOData/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Gem = JsonConvert.DeserializeObject<GemResponse>(content);
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
