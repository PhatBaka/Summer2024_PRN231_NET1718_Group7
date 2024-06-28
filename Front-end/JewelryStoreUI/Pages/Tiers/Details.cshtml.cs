using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JewelryStoreUI.Pages.Tiers
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

        public TierResponse Tier { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/tiers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var content = await response.Content.ReadAsStringAsync();
            Tier = JsonConvert.DeserializeObject<TierResponse>(content);

            return Page();
        }
    }
    public class TierResponse
    {
        [Key]
        public Guid? TierId { get; set; }

        public string? TierName { get; set; } = null!;

        public decimal? MinAmountSpent { get; set; }

        public decimal? DiscountPercentage { get; set; }

    }
}
