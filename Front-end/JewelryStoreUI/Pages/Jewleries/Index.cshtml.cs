using JewelryStoreUI.DTOs.Gems;
using JewelryStoreUI.DTOs.Jewelries;
using JewelryStoreUI.Pages.DTOs.Jewelry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace JewelryStoreUI.Pages.Jewleries
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public string? JewelryURL { get; private set; }
        public IList<JewelryResponse> JewelryData { get; private set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }

        public IndexModel(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task OnGetAsync(int currentPage = 1)
        {
            var baseUrl = _configuration.GetSection("API_ODATA_URL").Value;
            JewelryURL = $"{baseUrl}JewelryOData?$count=true&$top={PageSize}&$skip={(CurrentPage - 1) * PageSize}";
            CurrentPage = currentPage;
            try
            {
                var response = await _httpClient.GetAsync(JewelryURL);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var JewelryOData = JsonSerializer.Deserialize<JewelryOData>(jsonString);
                JewelryData = JewelryOData.Value;
                TotalCount = JewelryOData.Count;
            }
            catch (HttpRequestException e)
            {

            }
        }
    }
}

