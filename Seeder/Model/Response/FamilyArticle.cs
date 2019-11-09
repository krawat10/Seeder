using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class FamilyArticle
    {
        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; set; }

        [JsonProperty("url_key", NullValueHandling = NullValueHandling.Ignore)]
        public string UrlKey { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public FamilyArticleMedia[] Media { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("sizes", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Sizes { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public Price Price { get; set; }

        [JsonProperty("flags", NullValueHandling = NullValueHandling.Ignore)]
        public Flag[] Flags { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public Amount? Amount { get; set; }
    }
}