using JewelryStoreUI.DTOs.Carts;
using JewelryStoreUI.DTOs.Jewelries;
using JewelryStoreUI.DTOs.OrderDetails;
using JewelryStoreUI.DTOs.Orders;
using JewelryStoreUI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace JewelryStoreUI.Pages
{
    public class OrderScreenModel : PageModel
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

		public IList<JewelryCart> JewelryCarts { get; set; }
        private string BaseUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string OrderUrl { get; set; }

        public OrderScreenModel(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
            OrderUrl = $"{BaseUrl}Order";
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
                var JewelryOData = JsonSerializer.Deserialize<JewelryOData>(jsonString);
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
				MaterialImageData = Image,
                Id = JewelryId
            });
			HttpContext.Session.SetObjectAsJson("MATERIALCART", JewelryCarts);
			return Page();
		}

        public void LoadCart() => JewelryCarts = HttpContext.Session.GetObjectFromJson<IList<JewelryCart>>("MATERIALCART");

		public async Task<IActionResult> OnPostCreateOrderAsync()
		{
            await LoadJewelry(1);
            LoadCart();
            List<CreateOrderDetailRequest> createOrderDetailRequests = new List<CreateOrderDetailRequest>();
            // từ từ hanlde mua nhiều trang sức
            foreach(var item in JewelryCarts)
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

            var json = JsonSerializer.Serialize(orderRequest);

            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{OrderUrl}?orderTypeEnum=0", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Order created successfully.");
                    return RedirectToPage("Orders/Index");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }

            return Page();
        }
	}
}