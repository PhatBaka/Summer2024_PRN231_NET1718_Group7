using JewelryStoreUI.DTOs.Carts;
using JewelryStoreUI.DTOs.Gems;
using JewelryStoreUI.DTOs.Jewelries;
using JewelryStoreUI.DTOs.Metals;
using JewelryStoreUI.Enums;
using JewelryStoreUI.Helpers;
using JewelryStoreUI.Models.DTOs.Metals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace JewelryStoreUI.Pages.Jewleries
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public IList<MetalDTO> MetalDTOs = new List<MetalDTO>();
        [BindProperty]
        public string? Metal { get; set; }
        public string? GemURL { get; private set; }
        public IList<GemResponse>? GemData { get; private set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
        public IList<MetalCart> MetalCarts { get; set; }
        public IList<MaterialCart>? MaterialCarts { get; set; }
        public decimal GoldBid { get; set; }
        public decimal SilverBid { get; set; }
        public decimal PalladiumBid { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [BindProperty]
        public decimal MaterialWeight { get; set; }
        [BindProperty]
        public byte[] MaterialImage { get; set; }
        [BindProperty]
        public Guid MaterialId { get; set; }
        [BindProperty]
        public decimal MaterialPrice { get; set; }
        [BindProperty]
        public string MaterialName { get; set; }
        [BindProperty]
        public decimal GoldWeight { get; set; }
        [BindProperty]
        public decimal SilverWeight { get; set; }
        [BindProperty]
        public decimal PalladiumWeight { get; set; }
        public string MetalURL { get; set; }
        public string JewelryURL { get; set; }
        private readonly string _baseURL;
        public List<SelectListItem>? JewelryOptions { get; set; }
        [BindProperty]
        public CreateJewelryRequest CreateJewelryRequest { get; set; }
        List<Guid> materialIds = new List<Guid>();


        public CreateModel(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _baseURL = configuration.GetSection("API_URL").Value;
            MetalURL = $"{_baseURL}Metal";
            JewelryURL = $"{_baseURL}Jewelry";
            JewelryOptions = Enum.GetValues(typeof(JewelryCategory))
                     .Cast<JewelryCategory>()
                     .Select(e => new SelectListItem
                     {
                         Value = ((int)e).ToString(),
                         Text = e.ToString()
                     }).ToList();
        }

        public async Task<IActionResult> OnGetAsync(int currentPage = 1)
        {
            LoadPrice();
            await LoadGem(currentPage);
            return Page();
        }

        public async Task<IActionResult> OnPostAddMetalToCartAsync(int currentPage = 1)
        {
            LoadCart();
            LoadPrice();
            await LoadGem(1);
            
            if (MaterialId == Guid.Empty)
            {
                MetalCart metalItem = new MetalCart();
                metalItem.Name = Metal;
                metalItem.IsMetal = true;
                switch (metalItem.Name)
                {
                    case "gold":
                        metalItem.SellPrice = GoldBid;
                        break;
                    case "silver":
                        metalItem.SellPrice = SilverBid;
                        break;
                    case "palladium":
                        metalItem.SellPrice = PalladiumBid;
                        break;
                }
                MetalCarts ??= new List<MetalCart>();
                MetalCarts.Add(metalItem);
                HttpContext.Session.SetObjectAsJson("METALCART", MetalCarts);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddMaterialToCartAsync()
        {
            LoadCart();
            LoadPrice();
            await LoadGem(1);

            if (MaterialId == Guid.Empty)
            {
                MaterialCart metalItem = new MaterialCart();
                metalItem.Name = Metal;
                metalItem.IsMetal = true;
                switch (metalItem.Name)
                {
                    case "gold":
                        metalItem.CurrentPrice = GoldBid;
                        metalItem.SellPrice = GoldBid * GoldWeight;
                        metalItem.Weight = GoldWeight;
                        break;
                    case "silver":
                        metalItem.CurrentPrice = SilverBid;
                        metalItem.SellPrice = SilverBid * SilverWeight;
                        metalItem.Weight = SilverWeight;
                        break;
                    case "palladium":
                        metalItem.CurrentPrice = PalladiumBid;
                        metalItem.SellPrice = PalladiumBid * PalladiumWeight;
                        metalItem.Weight = PalladiumWeight;
                        break;
                }
                MaterialCarts ??= new List<MaterialCart>();
                MaterialCarts.Add(metalItem);
                HttpContext.Session.SetObjectAsJson("MATERIALCART", MaterialCarts);
            }
            else
            {
                MaterialCart materialItem = new MaterialCart();
                materialItem.IsMetal = false;
                materialItem.MaterialId = MaterialId;
                materialItem.MaterialImageData = MaterialImage;
                materialItem.SellPrice = MaterialPrice;
                materialItem.Name = MaterialName;
                materialItem.Weight = MaterialWeight;
                MaterialCarts ??= new List<MaterialCart>();
                MaterialCarts.Add(materialItem);
                HttpContext.Session.SetObjectAsJson("MATERIALCART", MaterialCarts);
            }
            return Page();
        }

        private void LoadCart()
        {
            var metalCart = HttpContext.Session.GetObjectFromJson<IList<MetalCart>>("METALCART");
            var materialCart = HttpContext.Session.GetObjectFromJson<IList<MaterialCart>>("MATERIALCART");
            MaterialCarts ??= new List<MaterialCart>();
            MetalCarts ??= new List<MetalCart>();
            if (materialCart != null)
                MaterialCarts = materialCart;
            if (metalCart != null)
                MetalCarts = metalCart;
        }

        public void LoadPrice()
        {
            MetalDTOs = HttpContext.Session.GetObjectFromJson<IList<MetalDTO>>("METALLIST");
            GoldBid = MetalDTOs.FirstOrDefault(x => x.Metal == "gold").Rate.Bid;
            SilverBid = MetalDTOs.FirstOrDefault(x => x.Metal == "silver").Rate.Bid;
            PalladiumBid = MetalDTOs.FirstOrDefault(x => x.Metal == "palladium").Rate.Bid;
            UpdatedDate = MetalDTOs.FirstOrDefault(x => x.Metal == "gold").Timestamp;
        }

        public async Task LoadGem(int currentPage)
        {
            var baseUrl = _configuration.GetSection("API_ODATA_URL").Value;
            GemURL = $"{baseUrl}GemOData?$count=true&$top={PageSize}&$skip={(CurrentPage - 1) * PageSize}";
            CurrentPage = currentPage;
            try
            {
                var response = await _httpClient.GetAsync(GemURL);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var gemOData = System.Text.Json.JsonSerializer.Deserialize<GemOData>(jsonString);
                GemData = gemOData.Value;
                TotalCount = gemOData.Count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task OnPostCreateJewelry()
        {
            LoadCart();
            LoadPrice();
            await LoadGem(1);

            var cart = HttpContext.Session.GetObjectFromJson<IList<MaterialCart>>("MATERIALCART");
            var metalInCart = cart.Where(x => x.IsMetal == true);
            var gemInCart = cart.Where(x => x.IsMetal == false);
            CreateJewelryRequest.JewelryType = JewelryType.HAVEGEM;

            if (metalInCart != null && metalInCart.Count() > 0)
            {
                foreach (var metal in metalInCart)
                {
                    await CreateMetalAsync(metal);
                }
            }
            if (gemInCart != null && gemInCart.Count() > 0)
            {
                foreach (var gem in gemInCart)
                {
                    materialIds.Add(gem.MaterialId);
                }
            }

            using (var content = new MultipartFormDataContent())
            {
                // Add the file content
                if (CreateJewelryRequest.JewelryImageFile != null)
                {
                    var fileContent = new StreamContent(CreateJewelryRequest.JewelryImageFile.OpenReadStream());
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(CreateJewelryRequest.JewelryImageFile.ContentType);
                    content.Add(fileContent, nameof(CreateJewelryRequest.JewelryImageFile), CreateJewelryRequest.JewelryImageFile.FileName);
                }

                // Add the other form fields
                content.Add(new StringContent(CreateJewelryRequest.JewelryId.ToString()), nameof(CreateJewelryRequest.JewelryId));
                content.Add(new StringContent(CreateJewelryRequest.JewelryName), nameof(CreateJewelryRequest.JewelryName));
                content.Add(new StringContent(CreateJewelryRequest.ManufacturingFees.ToString()), nameof(CreateJewelryRequest.ManufacturingFees));
                content.Add(new StringContent(CreateJewelryRequest.JewelryType.ToString()), nameof(CreateJewelryRequest.JewelryType));
                if (CreateJewelryRequest.GuaranteeDuration.HasValue)
                {
                    content.Add(new StringContent(CreateJewelryRequest.GuaranteeDuration.ToString()), nameof(CreateJewelryRequest.GuaranteeDuration));
                }
                if (CreateJewelryRequest.JewelryCategory.HasValue)
                {
                    content.Add(new StringContent(CreateJewelryRequest.JewelryCategory.ToString()), nameof(CreateJewelryRequest.JewelryCategory));
                }
                CreateJewelryRequest.MaterialIds = materialIds;
                if (CreateJewelryRequest.MaterialIds != null && CreateJewelryRequest.MaterialIds.Any())
                {
                    foreach (var materialId in materialIds)
                    {
                        content.Add(new StringContent(materialId.ToString()), nameof(CreateJewelryRequest.MaterialIds));
                    }
                }

                // Send the POST request
                var response = await _httpClient.PostAsync(JewelryURL, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    if (Guid.TryParse(responseBody, out Guid newJewelryId))
                    {
                        if (newJewelryId != null)
                        {

                        }
                    }
                }

            }
        }

        public async Task CreateMetalAsync(MaterialCart metalCart)
        {
            CreateMetalRequest createMetalRequest = new()
            {
                CurrentPrice = metalCart.SellPrice,
                Name = metalCart.Name,
                Weight = metalCart.Weight
            };

            var json = JsonConvert.SerializeObject(createMetalRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{MetalURL}?materialStatus=0", content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (Guid.TryParse(responseBody.Trim('"'), out Guid newMetalId))  // Remove quotes and parse
                {
                    materialIds.Add(newMetalId);
                }
            }
        }
    }
}