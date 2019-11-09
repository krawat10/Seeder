using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public class Price
    {
        [JsonProperty("original", NullValueHandling = NullValueHandling.Ignore)]
        public string Original { get; set; }

        [JsonProperty("promotional", NullValueHandling = NullValueHandling.Ignore)]
        public string Promotional { get; set; }

        [JsonProperty("has_different_prices", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasDifferentPrices { get; set; }

        [JsonProperty("has_different_original_prices", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasDifferentOriginalPrices { get; set; }

        [JsonProperty("has_different_promotional_prices", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasDifferentPromotionalPrices { get; set; }

        [JsonProperty("has_discount_on_selected_sizes_only", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasDiscountOnSelectedSizesOnly { get; set; }

        [JsonProperty("base_price", NullValueHandling = NullValueHandling.Ignore)]
        public string BasePrice { get; set; }
    }
}