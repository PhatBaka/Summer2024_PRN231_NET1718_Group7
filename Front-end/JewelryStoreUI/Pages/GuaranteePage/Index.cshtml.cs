using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JewelryStoreUI.Pages.DTOs.Jewelry;
using JewelryStoreUI.Pages.DTOs.Guarantee;
using Newtonsoft.Json;

namespace test1.Pages.GuaranteePage
{
    public class IndexModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        [BindProperty]
        public IList<CreateGuarantee> ResponseResult { get; set; }
        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string guaranteeURL;
        public IndexModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            guaranteeURL = url + "Guarantee";
            ResponseResult = new List<CreateGuarantee>();
        }

        public async Task OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(guaranteeURL);
                var result = await response.Content.ReadAsStringAsync();
                var entity = JsonConvert.DeserializeObject<IList<CreateGuarantee>>(result);
                if (entity != null)
                {
                    ResponseResult = entity;
                }
            }
        }
    }
}
