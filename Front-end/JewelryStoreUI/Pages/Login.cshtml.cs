using JewelryStoreUI.Enums;
using JewelryStoreUI.Pages.DTOs;
using JewelryStoreUI.Pages.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace JewelryStoreUI.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDTO Account { get; set; }
        [BindProperty]
        public ResponseResult<dynamic> ResponseResult { get; set; }
        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        public string? Message { get; set; }

        private void LoadData()
        {
            url += "Auth/Login";
            ResponseResult = new();
        }

        public void OnGet()
        {
            LoadData();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            LoadData();

            var json = JsonConvert.SerializeObject(Account);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, data);
                var result = await response.Content.ReadAsStringAsync();

                ResponseResult = JsonConvert.DeserializeObject<ResponseResult<dynamic>>(result);
            }
            if (ResponseResult.Result == true)
            {
                HttpContext.Session.SetInt32("ROLE", (int)ResponseResult.Data.role);
                if (ResponseResult.Data.role == RoleEnum.MANAGER)
                {
                    return RedirectToPage("Manager");
                }
                else if (ResponseResult.Data.role == RoleEnum.STAFF)
                {
                    return RedirectToPage("Staff");
                }
            }
            else if (ResponseResult.Result == false)
            {
                Message = ResponseResult.Message;
            }
            return Page();
        }
    }
}
