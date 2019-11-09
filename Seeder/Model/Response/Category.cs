using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class Category
    {
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("url_key", NullValueHandling = NullValueHandling.Ignore)]
        public string UrlKey { get; set; }

        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("seo_label", NullValueHandling = NullValueHandling.Ignore)]
        public string SeoLabel { get; set; }

        [JsonProperty("reset_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ResetUrl { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Id { get; set; }
    }
}