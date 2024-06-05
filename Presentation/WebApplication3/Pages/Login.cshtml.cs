using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication3.DTO;
using WebApplication3.Enum;

namespace WebApplication3.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public AccountViewModel AccountViewModel { get; set; }
        public string Message { get; set; }
        private HttpClient _httpClient;
        private string _apiUrl;

        public LoginModel()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            _apiUrl = config["API_URL"];
            _httpClient = new HttpClient();
            Message = null;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var requestBody = new
            {
                password = AccountViewModel.Password,
                email = AccountViewModel.Email
            };

            var jsonBody = JsonConvert.SerializeObject(requestBody);
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_apiUrl}Auth/Login");
            request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            // Send the request
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var jwtToken = await response.Content.ReadAsStringAsync();
                var handler = new JwtSecurityTokenHandler();
                var tokenS = handler.ReadToken(jwtToken) as JwtSecurityToken;
                var role = tokenS.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
                HttpContext.Session.SetString("JWT", jwtToken);
                if (role != null)
                {
                    Message = $"You are authorized as {role}";
                }
                else
                {
                    Message = "You are not allowed to access this function!";
                }
            }
            else
            {
                Message = "Login fail";
            }
            return Page();
        }
    }
}
