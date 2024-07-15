using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JewelryShop.DTO.DTOs
{
    public class MetalRate
    {
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("ask")]
        public decimal Ask { get; set; }

        [JsonPropertyName("bid")]
        public decimal Bid { get; set; }

        [JsonPropertyName("high")]
        public decimal High { get; set; }

        [JsonPropertyName("low")]
        public decimal Low { get; set; }

        [JsonPropertyName("change")]
        public decimal Change { get; set; }

        [JsonPropertyName("change_percent")]
        public decimal ChangePercent { get; set; }
    }

    public class PriceResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("metal")]
        public string Metal { get; set; }

        [JsonPropertyName("rate")]
        public MetalRate Rate { get; set; }
    }
}
