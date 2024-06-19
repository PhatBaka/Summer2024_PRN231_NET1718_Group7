using JewelryStoreUI.Pages.DTOs.Discount;
using JewelryStoreUI.Pages.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Promotions
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<StoreDiscountDTO> StoreDiscounts { get; set; }
        [BindProperty]
        public ResponseResult<dynamic> ResponseResult { get; set; }

        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;

        private void LoadData()
        {
            url += "StoreDiscount";
            ResponseResult = new ResponseResult<dynamic>();
        }

        public async Task<PageResult> OnGetAsync()
        {
            LoadData();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                if (result!= "[]")
                {
					dynamic responseResult = JsonConvert.DeserializeObject(result);
					ResponseResult.Data = JsonConvert.SerializeObject(responseResult);
					StoreDiscounts = JsonConvert.DeserializeObject<List<StoreDiscountDTO>>(ResponseResult.Data);
				}
            }
            return Page();
        }
    }
}
