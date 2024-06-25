namespace JewelryStoreUI.Helpers
{
	public static class Utils
	{
		public static string ReadJsonFile(string fileName)
		{
			string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

			if (!File.Exists(jsonFilePath))
			{
				throw new FileNotFoundException($"The file '{fileName}' was not found in the current directory.");
			}

			string jsonString = File.ReadAllText(jsonFilePath);
			return jsonString;
		}

        public static string FormatDate(string dateString, string currentFormat, string targetFormat)
        {
            if (DateTime.TryParseExact(dateString, currentFormat, null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime))
            {
                return parsedDateTime.ToString(targetFormat);
            }
            else
            {
                return null;
            }
        }
    }
}
