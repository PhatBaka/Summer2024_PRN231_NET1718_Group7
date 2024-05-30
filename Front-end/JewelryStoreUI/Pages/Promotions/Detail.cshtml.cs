using JewelryShop.DTO.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Promotions
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public StoreDiscountDTO StoreDiscount { get; set; }

        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            url += $"StoreDiscount/{id}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    StoreDiscount = JsonConvert.DeserializeObject<StoreDiscountDTO>(result);
                }
                else
                {
                    return NotFound();
                }
            }

            return Page();
        }
    }
}
