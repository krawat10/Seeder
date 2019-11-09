using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class CategoryTree
    {
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Id { get; set; }

        [JsonProperty("url_key", NullValueHandling = NullValueHandling.Ignore)]
        public string UrlKey { get; set; }

        [JsonProperty("has_skus", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasSkus { get; set; }

        [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Selected { get; set; }

        [JsonProperty("has_children", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasChildren { get; set; }

        [JsonProperty("full_url", NullValueHandling = NullValueHandling.Ignore)]
        public string FullUrl { get; set; }

        [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Children { get; set; }

        [JsonProperty("article_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? ArticleCount { get; set; }
    }
}