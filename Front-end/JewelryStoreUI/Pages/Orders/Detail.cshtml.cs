using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Orders
{
    public class DetailModel : PageModel
    {
        [BindProperty]
        public dynamic Order { get; set; }
        [BindProperty]
        public IList<dynamic> Orders { get; set; }
        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string orderUrl;

        public DetailModel()
        {
            orderUrl += $"{url}Order";
            Orders = new List<dynamic>();
        }

        public async Task OnGetAsync(string orderId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(orderUrl);
                var result = await response.Content.ReadAsStringAsync();
                Orders = JsonConvert.DeserializeObject<IList<dynamic>>(result);
                Order = Orders.FirstOrDefault(o => o.orderId == orderId);
            }
        }
    }
}
