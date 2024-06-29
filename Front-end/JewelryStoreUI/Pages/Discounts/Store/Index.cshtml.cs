using JewelryStoreUI.DTOs.Discounts.Orders;
using JewelryStoreUI.DTOs.Orders;
using JewelryStoreUI.DTOs.Promotions.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace JewelryStoreUI.Pages.Promotions.Store
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public string? StoreDiscountURL { get; private set; }
        public IList<StoreDiscountResponse> StoreDiscountData { get; private set; }
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
            StoreDiscountURL = $"{baseUrl}StoreDiscountOData?$count=true&$top={PageSize}&$skip={(CurrentPage - 1) * PageSize}";
            CurrentPage = currentPage;
            try
            {
                var response = await _httpClient.GetAsync(StoreDiscountURL);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var orderOData = JsonSerializer.Deserialize<StoreDiscountOData>(jsonString);
                StoreDiscountData = orderOData.Value;
                TotalCount = orderOData.Count;
            }
            catch (HttpRequestException e)
            {

            }
        }
    }
}
