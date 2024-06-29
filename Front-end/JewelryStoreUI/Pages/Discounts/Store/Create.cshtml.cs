using JewelryStoreUI.DTOs.Gems;
using JewelryStoreUI.DTOs.Promotions.Stores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace JewelryStoreUI.Pages.Promotions.Store
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public string? Message { get; set; }

        [BindProperty]
        public CreateStoreDiscountRequest StoreDiscount { get; set; }

        private string BaseUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string StoreDiscountUrl { get; set; }

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            StoreDiscountUrl += $"{BaseUrl}StoreDiscount";
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jsonContent = JsonSerializer.Serialize(StoreDiscount);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5042/api/StoreDiscount", content);

            if (response.IsSuccessStatusCode)
            {
                Message = "Discount created successfully!";
                return RedirectToPage("/Promotions/Store/Success"); // Redirect to a success page
            }
            else
            {
                Message = "Error creating discount.";
                return Page();
            }
        }
    }
}
