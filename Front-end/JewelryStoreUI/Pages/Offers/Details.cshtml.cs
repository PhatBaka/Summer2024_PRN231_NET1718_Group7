using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Offers
{
    public class DetailsModel : PageModel
    {
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public DetailsModel(IConfiguration configuration)
        {
            _apiUrl = configuration["API_URL"];
            _httpClient = new HttpClient();
        }

        public OfferResponse Offer { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/offers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var content = await response.Content.ReadAsStringAsync();
            Offer = JsonConvert.DeserializeObject<OfferResponse>(content);

            return Page();
        }
    }
    public class OfferResponse
    {
        public Guid OfferId { get; set; }

        public decimal? OfferPercent { get; set; }

        public string? Constraints { get; set; }
    }
}
