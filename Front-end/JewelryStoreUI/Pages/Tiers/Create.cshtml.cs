using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace JewelryStoreUI.Pages.Tiers
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
        public CreateTierRequest CreateTierRequest { get; set; }

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

            var json = JsonConvert.SerializeObject(CreateTierRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_apiUrl}/tiers", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }

            // Handle error
            return Page();
        }
    }
    public class CreateTierRequest
    {
        public string? TierName { get; set; } = null!;

        public decimal? MinAmountSpent { get; set; }

        public decimal? DiscountPercentage { get; set; }
    }
}
