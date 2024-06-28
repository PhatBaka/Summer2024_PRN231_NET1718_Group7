using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace JewelryStoreUI.Pages.Tiers
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
        public UpdateTierRequest UpdateTierRequest { get; set; }
        public Guid TierId { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/tiers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var content = await response.Content.ReadAsStringAsync();
            var tier = JsonConvert.DeserializeObject<TierResponse>(content);

            TierId = tier.TierId.Value;
            UpdateTierRequest = new UpdateTierRequest
            {
                TierName = tier.TierName,
                MinAmountSpent = tier.MinAmountSpent,
                DiscountPercentage = tier.DiscountPercentage
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var json = JsonConvert.SerializeObject(UpdateTierRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_apiUrl}/tiers/{TierId}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }

            // Handle error
            return Page();
        }
    }
    public class UpdateTierRequest
    {
        public string? TierName { get; set; } = null!;

        public decimal? MinAmountSpent { get; set; }

        public decimal? DiscountPercentage { get; set; }
    }
}
