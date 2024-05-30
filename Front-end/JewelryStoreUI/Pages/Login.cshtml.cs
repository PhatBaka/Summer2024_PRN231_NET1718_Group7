using JewelryStoreUI.Pages.Helpers;
using JewelryStoreUI.Pages.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace JewelryStoreUI.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginDTO LoginDTO { get; set; }
        [BindProperty]
        public ResponseResult<dynamic> ResponseResult { get; set; }
        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;

        private void LoadData()
        {
			url += "Auth/Login";
			ResponseResult = new ResponseResult<dynamic>();
		}

        public void OnGet()
        {
            LoadData();
		}

        public async Task<IActionResult> OnPostAsync()
        {
            LoadData();

            var json = JsonConvert.SerializeObject(LoginDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, data);
                var result = await response.Content.ReadAsStringAsync();

                dynamic responseResult = JsonConvert.DeserializeObject(result);
                ResponseResult.Result = responseResult.result;
                ResponseResult.Message = responseResult.message;
                ResponseResult.Data = JsonConvert.SerializeObject(responseResult.data);
            }
            return Page();
        }
    }
}