using JewelryStoreUI.Pages.DTOs.Cart;
using JewelryStoreUI.Pages.Helpers;
using JewelryStoreUI.Pages.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
		private string baseUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("API_URL").Value;
		private string jewelryUrl;
		private string imageUrl;
		private string orderUrl;

		public decimal TotalPrice = 0;

		public CartModel(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			Carts = new List<Cart>();
			Carts2 = new List<Cart>();
			jewelryUrl = $"{baseUrl}Jewelry/";
			imageUrl = $"{baseUrl}Image/";
			orderUrl = $"{baseUrl}Order";
		}

		public async Task OnGet()
        {
            Carts = GetCartItems();
			foreach (var cart in Carts)
			{
				jewelryUrl = $"{jewelryUrl}{cart.JewelryId}";
				using (var client = new HttpClient()) 
				{
					var response = await client.GetAsync(jewelryUrl);
					var result = await response.Content.ReadAsStringAsync();
					var entity = JsonConvert.DeserializeObject<dynamic>(result);
					cart.Data = entity;
					cart.Base64 = await GetImageAsync(entity.imageId);
				}
				TotalPrice += (decimal) cart.Data.sellPrice;
				Carts2.Add(cart);
                jewelryUrl = $"{baseUrl}Jewelry/";
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
			using (var client = new HttpClient())
			{
				var response = await client.GetAsync($"{imageUrl}{imageId}");
				var result = await response.Content.ReadAsStringAsync();
				var entity = JsonConvert.DeserializeObject<dynamic>(result);
				byte[] imageData = Convert.FromBase64String((string)entity.imageData);
				return Convert.ToBase64String(imageData);
			}
		}

		public async Task<IActionResult> OnPostAsync(string action)
		{
			IList<dynamic> OrderDetail = new List<dynamic>();
			foreach(var cart in GetCartItems())
			{
				OrderDetail.Add(new
				{
					JewelryId = cart.JewelryId,
					Quantity = cart.Quantity
				});
			}
			if (action == "checkout")
			{
				dynamic request = new
				{
					Status = 0,
					OrderType = 0,
					CustomerId = "84F4AFAF-2314-47FC-BD96-B4A4B8B7E399",
					OrderDetails = OrderDetail,
					AccountId = "BFFDC64B-B6D7-487A-A56E-D4C1AFDA8EF6"
				};
				var json = JsonConvert.SerializeObject(request);
				var data = new StringContent(json, Encoding.UTF8, "application/json");
				using (var client = new HttpClient())
				{

					var response = await client.PostAsync(orderUrl, data);
					var result = await response.Content.ReadAsStringAsync();
					
				}
				return RedirectToPage();
			}
			return Page();
		}
	}
}
