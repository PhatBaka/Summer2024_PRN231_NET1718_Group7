using JewelryStoreUI.Pages.DTOs.Jewelry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Jewleries
{
    public class IndexModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        [BindProperty]
        public IList<JewelryDTO> ResponseResult { get; set; }
        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string jewelryUrl;
        private string imageUrl;

        public IndexModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            jewelryUrl = url + "Jewelry";
            imageUrl = url + "Image/";
            ResponseResult = new List<JewelryDTO>();
        }

        public async Task OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(jewelryUrl);
                var result = await response.Content.ReadAsStringAsync();
                var entity = JsonConvert.DeserializeObject<IList<dynamic>>(result);
                foreach (var item in entity)
                {
                    ResponseResult.Add(new()
                    {
                        Base64 = await GetImageAsync(item.imageId),
                        Data = item,
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

        public IActionResult OnPost(string handler, string itemId)
        {
            if (handler == "AddToCart")
            {
                var existingItems = _httpContextAccessor.HttpContext.Request.Cookies["cartItems"];
                var updatedItems = string.IsNullOrEmpty(existingItems) ? itemId : $"{existingItems},{itemId}";
                _httpContextAccessor.HttpContext.Response.Cookies.Append("cartItems", updatedItems);
                return RedirectToPage();
            }
            return RedirectToPage();
        }
    }
}
