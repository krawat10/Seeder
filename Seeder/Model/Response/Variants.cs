using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class Variants
    {
        [JsonProperty("fullWidthCatalog", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FullWidthCatalog { get; set; }

        [JsonProperty("premiumCatalog", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PremiumCatalog { get; set; }

        [JsonProperty("myBrandsFilter", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MyBrandsFilter { get; set; }

        [JsonProperty("hideCategories", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HideCategories { get; set; }

        [JsonProperty("mobileLightFilters", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MobileLightFilters { get; set; }

        [JsonProperty("truncatedCount", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TruncatedCount { get; set; }

        [JsonProperty("smallFlags", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SmallFlags { get; set; }
    }
}