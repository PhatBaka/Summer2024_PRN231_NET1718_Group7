using JewelryStoreUI.Pages.DTOs.Order;
using JewelryStoreUI.Pages.DTOs.OrderDetail;
using JewelryStoreUI.Pages.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Orders
{
    public class DetailModel : PageModel
    {
        [BindProperty]
        public IList<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string orderUrl;
        private string imageUrl;

        public DetailModel()
        {
            imageUrl = $"{url}Image/";
            orderUrl += $"{url}Order/";
        }

        public async Task OnGetAsync(string orderId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{orderUrl}{orderId}");
                var result = await response.Content.ReadAsStringAsync();
                var entities = JsonConvert.DeserializeObject<dynamic>(result);
                foreach (var entity in entities.orderDetails)
                {
                    OrderDetails.Add(new()
                    {
                        Base64 = await GetImageAsync(entity.imageId),
                        Data = entity
                    });
                }
            }
        }

        public async Task<string> GetImageAsync(dynamic imageId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{imageUrl}{imageId}");
                var result = await response.Content.ReadAsStringAsync();
                var entity = JsonConvert.DeserializeObject<dynamic>(result);
                byte[] imageData = Convert.FromBase64String((string)entity.imageData);
                return Convert.ToBase64String(imageData);
            }
        }
    }
}
