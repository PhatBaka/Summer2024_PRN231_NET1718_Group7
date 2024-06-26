using JewelryStoreUI.DTOs.Gems;
using JewelryStoreUI.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace JewelryStoreUI.Pages.Gems
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseURL;

        public string? Message { get; set; }

        [BindProperty]
        public CreateGemRequest Gem { get; set; }

        public List<SelectListItem>? ClarityOptions { get; set; }

        public string GemURl { get; set; }

        public CreateModel(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseURL = configuration.GetSection("API_URL").Value;
            GemURl = $"{_baseURL}Gem";
            ClarityOptions = Enum.GetValues(typeof(ClarityEnum))
                                 .Cast<ClarityEnum>()
                                 .Select(e => new SelectListItem
                                 {
                                     Value = ((int)e).ToString(),
                                     Text = e.ToString()
                                 }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var content = new MultipartFormDataContent();

            // Add string fields
            content.Add(new StringContent(Gem.Name ?? string.Empty), nameof(Gem.Name));
            content.Add(new StringContent(Gem.Description ?? string.Empty), nameof(Gem.Description));

            // Add nullable fields
            content.Add(new StringContent(Gem.SellPrice.HasValue ? Gem.SellPrice.Value.ToString("F2") : string.Empty), nameof(Gem.SellPrice));
            content.Add(new StringContent(Gem.Weight.HasValue ? Gem.Weight.Value.ToString("F2") : string.Empty), nameof(Gem.Weight));
            content.Add(new StringContent(Gem.Purity.HasValue ? Gem.Purity.Value.ToString("F2") : string.Empty), nameof(Gem.Purity));

            // Add enum fields
            content.Add(new StringContent(Gem.Clarity.HasValue ? ((int)Gem.Clarity.Value).ToString() : string.Empty), nameof(Gem.Clarity));

            // Add optional string fields
            content.Add(new StringContent(Gem.Color ?? string.Empty), nameof(Gem.Color));
            content.Add(new StringContent(Gem.Sharp ?? string.Empty), nameof(Gem.Sharp));

            // Add file fields
            if (Gem.MaterialImageFile != null)
            {
                content.Add(new StreamContent(Gem.MaterialImageFile.OpenReadStream()), nameof(Gem.MaterialImageFile), Gem.MaterialImageFile.FileName);
            }
            else
            {
                content.Add(new StringContent(string.Empty), nameof(Gem.MaterialImageFile));
            }

            if (Gem.CertificateImageFile != null)
            {
                content.Add(new StreamContent(Gem.CertificateImageFile.OpenReadStream()), nameof(Gem.CertificateImageFile), Gem.CertificateImageFile.FileName);
            }
            else
            {
                content.Add(new StringContent(string.Empty), nameof(Gem.CertificateImageFile));
            }

            var response = await _httpClient.PostAsync(GemURl, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Gems/Index");
            }
            else
            {
                Message = "Error: Unable to create gem.";
                return Page();
            }
        }
    }
}
