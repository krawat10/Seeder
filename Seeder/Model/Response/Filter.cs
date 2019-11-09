using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class Filter
    {
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("url_key", NullValueHandling = NullValueHandling.Ignore)]
        public string UrlKey { get; set; }

        [JsonProperty("kind", NullValueHandling = NullValueHandling.Ignore)]
        public Kind? Kind { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public Value[] Values { get; set; }

        [JsonProperty("family_values", NullValueHandling = NullValueHandling.Ignore)]
        public FamilyValue[] FamilyValues { get; set; }

        [JsonProperty("family_key", NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyKey { get; set; }

        [JsonProperty("range", NullValueHandling = NullValueHandling.Ignore)]
        public Range Range { get; set; }
    }
}