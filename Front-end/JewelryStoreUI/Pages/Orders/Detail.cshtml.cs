using JewelryStoreUI.DTOs.Jewelries;
using JewelryStoreUI.DTOs.OrderDetails;
using JewelryStoreUI.DTOs.Orders;
using JewelryStoreUI.Enums;
using JewelryStoreUI.Pages.DTOs.OrderDetail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Orders
{
    public class DetailModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DetailModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public OrderResponse Order { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5233/odata/OrderOData/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Order = JsonConvert.DeserializeObject<OrderResponse>(content);
                return Page();
            }
            else
            {
                // Handle error response
                return NotFound();
            }
        }
    }
}
