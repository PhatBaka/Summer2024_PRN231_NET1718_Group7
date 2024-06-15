using Newtonsoft.Json;

namespace JewelryStoreUI.Helpers
{
	public static class Utils
	{
		public static async Task<string> GetImageAsync(string imageUrl)
		{
			using (var client = new HttpClient())
			{
				var response = await client.GetAsync($"{imageUrl}");
				response.EnsureSuccessStatusCode(); // Ensure the HTTP request is successful
				var result = await response.Content.ReadAsStringAsync();
				var entity = JsonConvert.DeserializeObject<dynamic>(result);
				byte[] imageData = Convert.FromBase64String((string)entity.imageData);
				return Convert.ToBase64String(imageData);
			}
		}
	}
}
