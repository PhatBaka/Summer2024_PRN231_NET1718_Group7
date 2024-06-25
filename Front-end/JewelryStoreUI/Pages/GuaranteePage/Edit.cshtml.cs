using JewelryStoreUI.Pages.DTOs.Guarantee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;

namespace test1.Pages.GuaranteePage
{
    public class EditModel : PageModel
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        [BindProperty]
        public IList<GuaranteeDTO> ResponseResult { get; set; }
        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string guaranteeURL;

        public EditModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            guaranteeURL = url + "Guarantee";
            /*ResponseResult = new List<GuaranteeDTO>();*/
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PutAsJsonAsync($"{guaranteeURL}/{Guarantee.GuaranteeId}", Guarantee);

                    if (!response.IsSuccessStatusCode)
                    {
                        // Log the error response details for debugging
                        var errorContent = await response.Content.ReadAsStringAsync();
                        // Optionally log this to a file or monitoring system
                        System.Diagnostics.Debug.WriteLine($"Error: {response.StatusCode}, Content: {errorContent}");
                        return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                    }

                    var result = await response.Content.ReadAsStringAsync();
                    Guarantee = JsonConvert.DeserializeObject<UpdateGuarantee>(result);
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
