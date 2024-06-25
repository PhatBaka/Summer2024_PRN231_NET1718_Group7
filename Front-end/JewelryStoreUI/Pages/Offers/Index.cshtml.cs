using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Offers
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

        public IList<OfferResponse> Offers { get; set; }

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/offers");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Offers = JsonConvert.DeserializeObject<List<OfferResponse>>(content);
            }
            else
            {
                Offers = new List<OfferResponse>();
            }
        }
    }
}
