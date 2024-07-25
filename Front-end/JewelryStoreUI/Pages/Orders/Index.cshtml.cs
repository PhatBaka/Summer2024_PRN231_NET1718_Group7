using JewelryStoreUI.DTOs.Jewelries;
using JewelryStoreUI.DTOs.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace JewelryStoreUI.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public string? OrderURL { get; private set; }
        public IList<OrderResponse> OrderData { get; private set; }
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
            OrderURL = "http://localhost:5233/odata/OrderOData";
            CurrentPage = currentPage;
            try
            {
                var response = await _httpClient.GetAsync(OrderURL);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var orderOData = JsonSerializer.Deserialize<OrderOData>(jsonString);
                OrderData = orderOData.Value;
                TotalCount = orderOData.Count;
            }
            catch (HttpRequestException e)
            {

            }
        }
    }
}
