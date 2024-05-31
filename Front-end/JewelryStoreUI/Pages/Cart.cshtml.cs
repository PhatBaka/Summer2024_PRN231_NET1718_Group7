using JewelryStoreUI.Pages.DTOs.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;

namespace JewelryStoreUI.Pages
{
    public class CartModel : PageModel
    {
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string? cartItemsCookie;
		[BindProperty]
		public IList<Cart> Carts { get; set; }
		[BindProperty]
		public IList<Cart> Carts2 { get; set; }
		private readonly HttpClient _httpClient;
		private string baseUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
		private string jewelryUrl;
		private string imageUrl;

		public CartModel(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			Carts = new List<Cart>();
			Carts2 = new List<Cart>();
			_httpClient = new HttpClient();
			jewelryUrl = $"{baseUrl}Jewelry/";
			imageUrl = $"{baseUrl}Image/";
		}

		public async Task OnGet()
        {
			Carts = GetCartItems();
			foreach (var cart in Carts)
			{
				jewelryUrl = $"{jewelryUrl}{cart.JewelryId}";
				using (var client = _httpClient) 
				{
					var response = await _httpClient.GetAsync(jewelryUrl);
					var result = await response.Content.ReadAsStringAsync();
					var entity = JsonConvert.DeserializeObject<dynamic>(result);
					cart.Data = entity;
					cart.Base64 = await GetImageAsync(entity.imageId);
				}
				Carts2.Add(cart);
			}
		}

		public IActionResult OnPostClearCart()
		{
			// Delete the "cartItems" cookie
			_httpContextAccessor.HttpContext.Response.Cookies.Delete("cartItems");

			// Redirect back to the same page or wherever appropriate
			return RedirectToPage();
		}

		public List<Cart> GetCartItems()
		{
			var cartItemsCookie = _httpContextAccessor.HttpContext.Request.Cookies["cartItems"];

			if (string.IsNullOrEmpty(cartItemsCookie))
			{
				return new List<Cart>();
			}

			var cartItems = cartItemsCookie.Split(',');

			var cartDictionary = new Dictionary<Guid, int>();

			foreach (var item in cartItems)
			{
				if (Guid.TryParse(item, out Guid jewelryId))
				{
					if (cartDictionary.ContainsKey(jewelryId))
					{
						cartDictionary[jewelryId]++;
					}
					else
					{
						cartDictionary[jewelryId] = 1;
					}
				}
			}

			return cartDictionary.Select(kvp => new Cart { JewelryId = kvp.Key, Quantity = kvp.Value }).ToList();
		}
		public async Task<string> GetImageAsync(dynamic imageId)
		{
			using (var client = _httpClient)
			{
				var response = await client.GetAsync($"{imageUrl}{imageId}");
				var result = await response.Content.ReadAsStringAsync();
				var entity = JsonConvert.DeserializeObject<dynamic>(result);
				byte[] imageData = Convert.FromBase64String((string)entity.imageData);
				return Convert.ToBase64String(imageData);
			}
		}
	}
}
