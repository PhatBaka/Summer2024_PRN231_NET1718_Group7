using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JewelryStoreUI.Pages.DTOs.Jewelry;
using JewelryStoreUI.Pages.DTOs.Guarantee;
using Newtonsoft.Json;
using JewelryStoreUI.Enums;

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
        public async Task<IActionResult> OnPostCreateOrderAsync()
        {
            CreateGuarantee guarantee = new CreateGuarantee();
            guarantee.DateReceive = DateTime.Now;
            guarantee.Confirm = GuaranteeEnum.CREATE.ToString();
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync($"{guaranteeURL}", guarantee);

                    if (!response.IsSuccessStatusCode)
                    {
                        // Log the error response details for debugging
                        var errorContent = await response.Content.ReadAsStringAsync();
                        // Optionally log this to a file or monitoring system
                        System.Diagnostics.Debug.WriteLine($"Error: {response.StatusCode}, Content: {errorContent}");
                        return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                    }

                    /*var result = await response.Content.ReadAsStringAsync();
                    Guarantee = JsonConvert.DeserializeObject<CreateGuarantee>(result);*/
                }
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                System.Diagnostics.Debug.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            OnGetAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostUpdateOrderAsync(Guid GuaranteeId, string newStatus)
        {
            await OnGetAsync();

            var entity = ResponseResult.FirstOrDefault(x => x.GuaranteeId == GuaranteeId);
            UpdateGuarantee guarantee = new UpdateGuarantee();
            if(newStatus == GuaranteeEnum.CREATE.ToString())
            {
                guarantee.DateReceive = entity.DateReceive;
                guarantee.DateComplete = DateTime.Now;
                guarantee.Confirm = GuaranteeEnum.ONGOING.ToString();
            }
            if (newStatus == GuaranteeEnum.ONGOING.ToString())
            {
                guarantee.DateReceive = entity.DateReceive;
                guarantee.DateComplete = entity.DateComplete;
                guarantee.DateBack = DateTime.Now;
                guarantee.Confirm = GuaranteeEnum.FINISH.ToString();
            }
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PutAsJsonAsync($"{guaranteeURL}/{GuaranteeId}", guarantee);

                    if (!response.IsSuccessStatusCode)
                    {
                        // Log the error response details for debugging
                        var errorContent = await response.Content.ReadAsStringAsync();
                        // Optionally log this to a file or monitoring system
                        System.Diagnostics.Debug.WriteLine($"Error: {response.StatusCode}, Content: {errorContent}");
                        return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    /*Guarantee = JsonConvert.DeserializeObject<UpdateGuarantee>(result);*/
                }
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                System.Diagnostics.Debug.WriteLine($"Exception: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
