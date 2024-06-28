using JewelryStoreUI.Enums;
using JewelryStoreUI.Helpers;
using JewelryStoreUI.Models.DTOs.Metals;
using JewelryStoreUI.Pages.DTOs;
using JewelryStoreUI.Pages.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace JewelryStoreUI.Pages
{
    public class LoginModel : PageModel
    {
        public IList<MetalDTO> MetalDTOs = new List<MetalDTO>();
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
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var gold = JsonSerializer.Deserialize<MetalDTO>(Utils.ReadJsonFile("gold.json"), options);
            var silver = JsonSerializer.Deserialize<MetalDTO>(Utils.ReadJsonFile("silver.json"), options);
            var palladium = JsonSerializer.Deserialize<MetalDTO>(Utils.ReadJsonFile("palladium.json"), options);
            if (gold != null && silver != null && palladium != null)
            {
                MetalDTOs.Add(gold);
                MetalDTOs.Add(silver);
                MetalDTOs.Add(palladium);
            }
            HttpContext.Session.SetObjectAsJson("METALLIST", MetalDTOs);
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
                    string id = ResponseResult.Data.accountId;
                    HttpContext.Session.SetString("STAFFID", id);
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
