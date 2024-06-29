using JewelryStoreUI.DTOs.Carts;
using JewelryStoreUI.DTOs.Discounts.Orders;
using JewelryStoreUI.DTOs.Jewelries;
using JewelryStoreUI.DTOs.OrderDetails;
using JewelryStoreUI.DTOs.Orders;
using JewelryStoreUI.DTOs.Promotions.Stores;
using JewelryStoreUI.Enums;
using JewelryStoreUI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace JewelryStoreUI.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public string? JewelryURL { get; private set; }
        public IList<JewelryResponse> JewelryData { get; private set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
        [BindProperty]
        public Guid JewelryId { get; set; }
        [BindProperty]
        public string JewelyName { get; set; }
        [BindProperty]
        public decimal UnitPrice { get; set; }
        [BindProperty]
        public byte[] Image { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        public decimal TotalUnitPrice { get; set; }
        public decimal TotalDiscountPrice { get; set; }
        public decimal TotalFinalPrice { get; set; }

        public IList<JewelryCart> JewelryCarts { get; set; }
        private string BaseUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string OrderUrl { get; set; }
        [BindProperty]
        public string DiscountCode { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public string DiscountName { get; set; }
        private string OrderDiscountURL { get; set; }

        public CreateModel(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            OrderUrl = $"{BaseUrl}Order";
            OrderDiscountURL = $"{BaseUrl}OrderDiscount";

        }

        public async Task OnGetAsync(int currentPage = 1)
        {
            await LoadJewelry(currentPage);
        }

        public async Task LoadJewelry(int currentPage)
        {
            var baseUrl = _configuration.GetSection("API_ODATA_URL").Value;
            JewelryURL = $"{baseUrl}JewelryOData?$count=true&$top={PageSize}&$skip={(CurrentPage - 1) * PageSize}";
            CurrentPage = currentPage;
            try
            {
                var response = await _httpClient.GetAsync(JewelryURL);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var JewelryOData = System.Text.Json.JsonSerializer.Deserialize<JewelryOData>(jsonString);
                JewelryData = JewelryOData.Value;
                TotalCount = JewelryOData.Count;
            }
            catch (HttpRequestException e)
            {

            }
        }

        public async Task<IActionResult> OnPostAddToCartAsync()
        {
            await LoadJewelry(1);
            LoadCart();
            JewelryCarts ??= new List<JewelryCart>();
            JewelryCarts.Add(new()
            {
                Name = JewelyName,
                UnitPrice = UnitPrice,
                FinalPrice = UnitPrice,
                MaterialImageData = Image,
                Id = JewelryId
            });
            UpdateTotalPrice(JewelryCarts);
            HttpContext.Session.SetObjectAsJson("MATERIALCART", JewelryCarts);
            return Page();
        }

        public void UpdateTotalPrice(IList<JewelryCart> jewelryCarts, decimal? discountAmount = null)
        {
            foreach (var jewelry in jewelryCarts)
            {
                TotalUnitPrice += jewelry.UnitPrice;
                if (discountAmount != null)
                {
                    TotalDiscountPrice = (decimal)(TotalUnitPrice * discountAmount / 100);
                }
                TotalFinalPrice = TotalUnitPrice - TotalDiscountPrice;
            }
        }

        public void LoadCart() => JewelryCarts = HttpContext.Session.GetObjectFromJson<IList<JewelryCart>>("MATERIALCART");

        public async Task<IActionResult> OnPostCreateOrderAsync()
        {
            await LoadJewelry(1);
            LoadCart();

            List<CreateOrderDetailRequest> createOrderDetailRequests = new List<CreateOrderDetailRequest>();
            // từ từ hanlde mua nhiều trang sức
            foreach (var item in JewelryCarts)
            {
                createOrderDetailRequests.Add(new()
                {
                    JewelryId = (Guid)item.Id,
                });
            }
            var orderRequest = new CreateOrderRequest
            {
                AccountId = Guid.Parse(HttpContext.Session.GetString("STAFFID")),
                PhoneNumber = PhoneNumber,
                OrderDetails = createOrderDetailRequests
            };

            var json = System.Text.Json.JsonSerializer.Serialize(orderRequest);

            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var url = $"{OrderUrl}";

                var code = HttpContext.Session.GetString("ORDERDISCOUNTID");

                if (code != null)
                {
                    url += $"?orderDiscountId={code}";
                }

                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostClearCart()
        {
            await LoadJewelry(1);
            HttpContext.Session.Clear();
            return Page();
        }

        public async Task<IActionResult> OnPostApplyDiscount()
        {
            LoadCart();
            await LoadJewelry(1);
            var response = await _httpClient.GetAsync($"http://localhost:5042/api/StoreDiscount/ByCode/{DiscountCode}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<StoreDiscountResponse>(content);
                DiscountName = data.DiscountCode;
                DiscountPercentage = data.DiscountAmount;
                UpdateTotalPrice(JewelryCarts, data.DiscountAmount);
                var discountRequest = new CreateOrderDiscountRequest
                {
                    StoreDiscountId = data.StoreDiscountId,
                    Type = DiscountType.STORE.ToString(),
                    Value = (decimal) data.DiscountAmount
                };
                // hiện tại chỉ áp được một mã giảm giá
                HttpContext.Session.SetString("ORDERDISCOUNTID", CreateOrderDisount(discountRequest).Result.ToString());
            }
            else
            {
                // Handle error response
                return NotFound();
            }
            return Page();
        }

        public async Task <Guid> CreateOrderDisount(CreateOrderDiscountRequest createOrderDiscountRequest)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(createOrderDiscountRequest);

            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{OrderDiscountURL}", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    // Remove the surrounding quotes and parse to Guid
                    var guidString = responseString.Trim('"');
                    return Guid.Parse(guidString);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            return Guid.Empty;
        }
    }
}
