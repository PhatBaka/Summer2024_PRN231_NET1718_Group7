using JewelryStoreUI.Pages.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelryStoreUI.Pages.Jewleries
{
    public class IndexModel : PageModel
    {
		[BindProperty]
		public ResponseResult<dynamic> ResponseResult { get; set; }
		private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;

        private void LoadData()
        {
			url += "Auth/Login";
		}

		public void OnGet()
        {
        }
    }
}
