using JewelryStoreUI.Pages.DTOs.StoreDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelryStoreUI.Pages.StoreDiscounts
{
    public class UpdateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        [BindProperty]
        public StoreDiscountDTO StoreDiscount { get; set; }

        public UpdateModel(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiUrl = configuration.GetSection("API_URL").Value;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var url = $"{_apiUrl}/StoreDiscount/{id}";
            StoreDiscount = await _httpClient.GetFromJsonAsync<StoreDiscountDTO>(url);

            if (StoreDiscount == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updateRequest = new UpdateStoreDiscountRequest
            {
                DiscountCode = StoreDiscount.DiscountCode,
                DiscountAmount = StoreDiscount.DiscountAmount,
                StartDate = StoreDiscount.StartDate,
                EndDate = StoreDiscount.EndDate,
                RemainingUsage = StoreDiscount.RemainingUsage
            };

            var url = $"{_apiUrl}/StoreDiscount/{id}";
            var response = await _httpClient.PutAsJsonAsync(url, updateRequest);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/StoreDiscounts/Index");
            }

            // Handle error response
            ModelState.AddModelError(string.Empty, "An error occurred while updating the discount.");
            return Page();
        }
    }
}
