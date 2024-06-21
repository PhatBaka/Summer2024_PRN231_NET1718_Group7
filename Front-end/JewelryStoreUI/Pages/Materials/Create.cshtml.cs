using JewelryStoreUI.Pages.DTOs;
using JewelryStoreUI.Pages.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace JewelryStoreUI.Pages.Materials
{

    public class CreateModel : PageModel
    {
        [BindProperty]
        public AddMaterialDTO AddMaterialDTO { get; set; }
        [BindProperty]
        public ResponseResult<dynamic> ResponseResult { get; set; }
        private string url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string url1 = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;

        private dynamic responseResult;
        private void AddImage()
        {
            url += "Image";
            url1 += "Material";
            ResponseResult = new ResponseResult<dynamic>();
        }
        public void OnGet()
        {
            AddImage();
        }
        [HttpPost]
        public async Task<IActionResult> OnPostAddMaterialAsync()
        {
            AddImage();

            using (var client = new HttpClient())
            {

                using (var content = new MultipartFormDataContent())
                {
                    if (AddMaterialDTO.ImageData != null)
                    {
                        using var stream = AddMaterialDTO.ImageData.OpenReadStream();
                        var fileContent = new StreamContent(stream);
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue(AddMaterialDTO.ImageData.ContentType);
                        content.Add(fileContent, "ImageData", AddMaterialDTO.ImageData.FileName);

                        var response = await client.PostAsync(url, content);
                        var result = await response.Content.ReadAsStringAsync();

                        responseResult = JsonConvert.DeserializeObject(result);
                    }
                }

                if (AddMaterialDTO.Name != null && AddMaterialDTO.Description != null && responseResult != null)
                {
                    var data = new
                    {
                        name = AddMaterialDTO.Name ?? string.Empty,
                        description = AddMaterialDTO.Description ?? string.Empty,
                        imageId = responseResult ?? string.Empty
                    };

                    var response = await client.PostAsJsonAsync(url1, data);
                    var result = await response.Content.ReadAsStringAsync();

                    dynamic responseResult1 = JsonConvert.DeserializeObject(result);
                }

                return Page();
            }
        }
    }
}
