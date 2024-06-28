using JewelryStoreUI.Pages.DTOs.StoreDiscount;
using JewelryStoreUI.Pages.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.StoreDiscounts
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public StoreDiscountDTO StoreDiscountDTO { get; set; }
        [BindProperty]
        public ResponseResult<dynamic> ResponseResult { get; set; }

        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;

        private void InitializeUrls()
        {
            url += "StoreDiscount";
            ResponseResult = new ResponseResult<dynamic>();
        }

        public void OnGet()
        {
            InitializeUrls();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAddStoreDiscountAsync()
        {
            InitializeUrls();

            using (var client = new HttpClient())
            {
                var data = new
                {
                    discountCode = StoreDiscountDTO.DiscountCode ?? string.Empty,
                    discountAmount = StoreDiscountDTO.DiscountAmount ?? 0,
                    startDate = StoreDiscountDTO.StartDate?.ToString("yyyy-MM-dd") ?? string.Empty,
                    endDate = StoreDiscountDTO.EndDate?.ToString("yyyy-MM-dd") ?? string.Empty,
                    remainingUsage = StoreDiscountDTO.RemainingUsage ?? 0
                };

                var response = await client.PostAsJsonAsync(url, data);
                var result = await response.Content.ReadAsStringAsync();

                ResponseResult.Data = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(result));
            }

            return Page();
        }
    }
}
