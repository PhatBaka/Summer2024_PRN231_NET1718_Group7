using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Tiers
{
    public class IndexModel : PageModel
    {
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public IndexModel(IConfiguration configuration)
        {
            _apiUrl = configuration["API_URL"];
            _httpClient = new HttpClient();
        }

        public IList<TierResponse> Tiers { get; set; }

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/tiers");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Tiers = JsonConvert.DeserializeObject<List<TierResponse>>(content);
            }
            else
            {
                Tiers = new List<TierResponse>();
            }
        }
    }
}
