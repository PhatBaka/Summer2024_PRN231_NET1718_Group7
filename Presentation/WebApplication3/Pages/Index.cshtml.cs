using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public string Message { get; set; }
        private HttpClient _httpClient;
        private string _apiUrl;
        public string ResponseString;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            _apiUrl = config["API_URL"];
            _httpClient = new HttpClient();
            Message = null;
        }

        public async Task<IActionResult> OnGet()
        {
            string jwt = HttpContext.Session.GetString("JWT");
            if (jwt == null)
            {
                return RedirectToPage("Login");
            } 
            else
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                    var response = await client.GetAsync($"{_apiUrl}Customer/AdminGetAccount");
                    if (response.IsSuccessStatusCode)
                    {
                        ResponseString = await response.Content.ReadAsStringAsync();

                        var handler = new JwtSecurityTokenHandler();
                        var tokenS = handler.ReadToken(jwt) as JwtSecurityToken;
                        var role = tokenS.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;

                        Message = $"You are authorized as {role}";          
                    }
                    else
                    {
                        Message = "Error: Unable to authorize";
                    }
                }
            }
            return Page();
        }
    }
}
