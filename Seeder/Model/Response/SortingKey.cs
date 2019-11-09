using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class SortingKey
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("dir", NullValueHandling = NullValueHandling.Ignore)]
        public string Dir { get; set; }

        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }
    }
}