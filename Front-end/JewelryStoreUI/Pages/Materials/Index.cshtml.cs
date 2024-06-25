using JewelryStoreUI.Pages.DTOs;
using JewelryStoreUI.Pages.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JewelryStoreUI.Pages.Materials
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<MaterialsDTO> Materials { get; set; }
        [BindProperty]
        public ResponseResult<dynamic> ResponseResult { get; set; }
        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private void LoadData()
        {
            url += "Material";
            ResponseResult = new ResponseResult<dynamic>();
        }
        public async Task<PageResult> OnGetAsync()
        {
            LoadData();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                dynamic responseResult = JsonConvert.DeserializeObject(result);
                /*ResponseResult.Result = responseResult.result;
				ResponseResult.Message = responseResult.message;*/
                ResponseResult.Data = JsonConvert.SerializeObject(responseResult);
                Materials = JsonConvert.DeserializeObject<List<MaterialsDTO>>(ResponseResult.Data);
            }
            return Page();
        }

    }
}
