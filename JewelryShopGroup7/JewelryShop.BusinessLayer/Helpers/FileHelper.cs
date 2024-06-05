using Microsoft.AspNetCore.Http;

namespace JewelryShop.BusinessLayer.Helpers
{
    public static class FileHelper
    {
        public static async Task<byte[]> ConvertToByteArrayAsync(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "File cannot be null.");
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
