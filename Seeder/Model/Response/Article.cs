using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public class Article
    {
        [JsonIgnore]
        public long ean;

        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public Price Price { get; set; }

        [JsonProperty("sizes", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Sizes { get; set; }

        [JsonProperty("url_key", NullValueHandling = NullValueHandling.Ignore)]
        public string UrlKey { get; set; }

        [JsonProperty("brand_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BrandName { get; set; }

        [JsonProperty("is_premium", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPremium { get; set; }

        [JsonProperty("product_group", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductGroup { get; set; }

        [JsonProperty("outfits", NullValueHandling = NullValueHandling.Ignore)]
        public Outfit[] Outfits { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public FamilyArticleMedia[] Media { get; set; }

        [JsonIgnore]
        public long Id { get; set; }

        public string Gender { get; set; }
    }
}