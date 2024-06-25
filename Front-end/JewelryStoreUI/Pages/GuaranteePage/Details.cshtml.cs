using JewelryStoreUI.Pages.DTOs.Guarantee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace test1.Pages.GuaranteePage
{
    public class DetailsModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        [BindProperty]
        public IList<GuaranteeDTO> ResponseResult { get; set; }
        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string guaranteeURL;
        public DetailsModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            guaranteeURL = url + "Guarantee";
        }

        [BindProperty]
        public UpdateGuarantee Guarantee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{guaranteeURL}/{id}");
                var result = await response.Content.ReadAsStringAsync();
                var entity = JsonConvert.DeserializeObject<UpdateGuarantee>(result);
                Guarantee = entity;
                /*ViewData["AccountId"] = new SelectList(GuaranteeDTO.Accounts, "AccountId", "Role");
                ViewData["OrderDetailId"] = new SelectList(_context.OrderDetails, "OrderDetailId", "OrderDetailId");*/
            }
            return Page();
        }
    }
}
