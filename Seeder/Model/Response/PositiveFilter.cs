using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class PositiveFilter
    {
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("url_key", NullValueHandling = NullValueHandling.Ignore)]
        public string UrlKey { get; set; }

        [JsonProperty("kind", NullValueHandling = NullValueHandling.Ignore)]
        public Kind? Kind { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public Category[] Values { get; set; }
    }
}