using JewelryStoreUI.DTOs.Gems;
using System.Text.Json.Serialization;

namespace JewelryStoreUI.DTOs
{
    public class ODataResponseBase<T>
    {
        [JsonPropertyName("@odata.context")]
        public string? Context { get; set; }

        [JsonPropertyName("value")]
        public List<T>? Value { get; set; }

        [JsonPropertyName("@odata.count")]
        public int Count { get; set; }
    }
}
