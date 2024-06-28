using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace JewelryStoreUI.Pages.Offers
{
    public class EditModel : PageModel
    {
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public EditModel(IConfiguration configuration)
        {
            _apiUrl = configuration["API_URL"];
            _httpClient = new HttpClient();
        }

        [BindProperty]
        public UpdateOfferRequest UpdateOfferRequest { get; set; }
        public Guid OfferId { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/offers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var content = await response.Content.ReadAsStringAsync();
            var offer = JsonConvert.DeserializeObject<OfferResponse>(content);

            OfferId = offer.OfferId;
            UpdateOfferRequest = new UpdateOfferRequest
            {
                OfferPercent = offer.OfferPercent,
                Constraints = offer.Constraints
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var json = JsonConvert.SerializeObject(UpdateOfferRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_apiUrl}/offers/{OfferId}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }

            // Handle error
            return Page();
        }
    }
    public class UpdateOfferRequest
    {
        public decimal? OfferPercent { get; set; }

        public string? Constraints { get; set; }
    }
}
