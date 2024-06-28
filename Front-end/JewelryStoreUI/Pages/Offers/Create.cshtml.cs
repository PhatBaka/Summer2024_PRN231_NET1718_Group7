using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace JewelryStoreUI.Pages.Offers
{
    public class CreateModel : PageModel
    {
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public CreateModel(IConfiguration configuration)
        {
            _apiUrl = configuration["API_URL"];
            _httpClient = new HttpClient();
        }

        [BindProperty]
        public CreateOfferRequest CreateOfferRequest { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var json = JsonConvert.SerializeObject(CreateOfferRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_apiUrl}/offers", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }

            // Handle error
            return Page();
        }
    }
    public class CreateOfferRequest
    {
        public decimal? OfferPercent { get; set; }

        public string? Constraints { get; set; }
    }
}
