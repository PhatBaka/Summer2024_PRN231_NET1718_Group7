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
        public string? MaterialURL { get; private set; }
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
        [BindProperty]
        public int Quantity { get; set; }
        public IList<JewelryCart> JewelryCarts { get; set; }
        private string BaseUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
        private string OrderUrl { get; set; }
        [BindProperty]
        public ICollection<ShortenMaterialResponse>? Materials { get; set; }
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
            MaterialURL = BaseUrl + "Order";
            var existingItem = JewelryCarts.FirstOrDefault(j => j.Id == JewelryId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                JewelryCarts.Add(new()
                {
                    Name = JewelyName,
                    UnitPrice = UnitPrice,
                    MaterialImageData = Image,
                    Id = JewelryId,
                    Quantity = 1
                });
            }
            if(Materials != null || Materials.Any())
            {
                foreach (var item in Materials)
                {
                    if (item.Name != null)
                    {
                        using (var client = new HttpClient())
                        {
                            var response = await client.PostAsJsonAsync($"{MaterialURL}/UpdateMaterialadd", item.Name);

                            if (!response.IsSuccessStatusCode)
                            {
                                // Log the error response details for debugging
                                var errorContent = await response.Content.ReadAsStringAsync();
                                // Optionally log this to a file or monitoring system
                                System.Diagnostics.Debug.WriteLine($"Error: {response.StatusCode}, Content: {errorContent}");
                                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                            }
                        }
                    }
                }
            }
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
                var jewelryData = JewelryData.FirstOrDefault(j => j.JewelryId == item.Id);
                if (jewelryData == null || item.Quantity <= 0 || item.Quantity > jewelryData.Quantity)
                {
                    ModelState.AddModelError(string.Empty, $"Invalid quantity for item: {item.Name}. Available quantity: {jewelryData?.Quantity ?? 0}");
                    return Page();
                }
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
        public async Task<IActionResult> OnPostRemoveFromCartAsync(Guid id)
        {
            await LoadJewelry(1);
            LoadCart();

            var itemToRemove = JewelryCarts.FirstOrDefault(j => j.Id == id);
            if (itemToRemove != null)
            {
                JewelryCarts.Remove(itemToRemove);
                HttpContext.Session.SetObjectAsJson("MATERIALCART", JewelryCarts);
            }

            return Page();
        }

    }
}