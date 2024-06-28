using JewelryStoreUI.DTOs.Gems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JewelryStoreUI.Pages.Gems
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public string? GemURL { get; private set; }
        public IList<GemResponse> GemData { get; private set; }
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
            GemURL = $"{baseUrl}GemOData?$count=true&$top={PageSize}&$skip={(CurrentPage - 1) * PageSize}";
            CurrentPage = currentPage;
            try
            {
				var response = await _httpClient.GetAsync(GemURL);
				response.EnsureSuccessStatusCode();
				var jsonString = await response.Content.ReadAsStringAsync();
				var gemOData = JsonSerializer.Deserialize<GemOData>(jsonString);
                GemData = gemOData.Value;
                TotalCount = gemOData.Count;
            }
            catch (HttpRequestException e)
            {

            }
        }
    }
}
