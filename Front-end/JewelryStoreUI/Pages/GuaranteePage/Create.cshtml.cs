using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JewelryStoreUI.Pages.DTOs.Guarantee;
using Newtonsoft.Json;

namespace test1.Pages.GuaranteePage
{
    public class CreateModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        [BindProperty]
        public IList<GuaranteeDTO> ResponseResult { get; set; }
        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string guaranteeURL;

        public CreateModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            guaranteeURL = url + "Guarantee";
        }

        /*public IActionResult OnGet()
        {
        
        }*/

        [BindProperty]
        public CreateGuarantee Guarantee { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsJsonAsync($"{guaranteeURL}", Guarantee);

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
        }
    }
}
