using JewelryStoreUI.Enums;
using JewelryStoreUI.Pages.DTOs;
using JewelryStoreUI.Pages.DTOs.Jewelry;
using JewelryStoreUI.Pages.DTOs.Material;
using JewelryStoreUI.Pages.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace JewelryStoreUI.Pages.Jewleries
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateJewelryDTO CreateJewelryDTO { get; set; }
        [BindProperty]
        public string MaterialListJson { get; set; }
        public IList<CreateJewelryMeterialDTO> CreateJewelryMeterialDTOs { get; set; }
        public decimal TotalPrice { get; set; }
        public IList<MaterialDTO> MaterialList { get; set; }
        private string baseUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string materialUrl;
        private string imageUrl;
        private string jewelryUrl;

        public CreateModel()
        {
            materialUrl = baseUrl + "Material";
            jewelryUrl = baseUrl + "Jewelry";
            imageUrl = baseUrl + "Image/";
            MaterialList = new List<MaterialDTO>();
        }

        private async Task GetData()
        {
            await GetMaterial();
        }

        public async Task OnGetAsync()
        {
            await GetData();
        }

        private async Task GetMaterial()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(materialUrl);
                var result = await response.Content.ReadAsStringAsync();
                var entity = JsonConvert.DeserializeObject<IList<dynamic>>(result);
                foreach (var item in entity)
                {
                    MaterialList.Add(new()
                    {
                        Base64 = await GetImageAsync(item.imageId),
                        Data = item,
                    });
                }
            }
        }

        private async Task<string> GetImageAsync(dynamic imageId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{imageUrl}{imageId}");
                var result = await response.Content.ReadAsStringAsync();
                var entity = JsonConvert.DeserializeObject<dynamic>(result);
                byte[] imageData = Convert.FromBase64String((string)entity.imageData);
                return Convert.ToBase64String(imageData);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            dynamic ReponseResult;
            await GetData();
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            if (!string.IsNullOrEmpty(MaterialListJson))
            {
                CreateJewelryDTO.CreateJewelryMeterialDTOs = JsonConvert.DeserializeObject<List<CreateJewelryMeterialDTO>>(MaterialListJson);
            }

            using (var client = new HttpClient())
            {

                using (var content = new MultipartFormDataContent())
                {
                    using var stream = CreateJewelryDTO.Image.OpenReadStream();
                    var fileContent = new StreamContent(stream);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(CreateJewelryDTO.Image.ContentType);
                    content.Add(fileContent, "ImageFile", CreateJewelryDTO.Image.FileName);

                    var imageResponse = await client.PostAsync(imageUrl, content);
                    var imageResult = await imageResponse.Content.ReadAsStringAsync();

                    ReponseResult = JsonConvert.DeserializeObject(imageResult);
                }

                var data = new
                {
                    jewelryName = CreateJewelryDTO.JewelryName,
                    manufacturingFees = CreateJewelryDTO.ManufacturerFee,
                    jewelryType = CreateJewelryDTO.JewelryType,
                    status = ObjectStatus.ACTIVE.ToString(),
                    guaranteeDuration = CreateJewelryDTO.GuaranteeDuration,
                    imageId = ReponseResult,
                    quantity = CreateJewelryDTO.Quantity,
                    markupPercentage = CreateJewelryDTO.MarkupPercentage,
                    createJewelryMeterialDTOs = CreateJewelryDTO.CreateJewelryMeterialDTOs
                };

                var response = await client.PostAsJsonAsync(jewelryUrl, data);
                var result = await response.Content.ReadAsStringAsync();

                dynamic responseResult1 = JsonConvert.DeserializeObject(result);
            }
            return Page();
        }
    }
}
