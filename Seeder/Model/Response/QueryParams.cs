using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class QueryParams
    {
        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public string Categories { get; set; }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public string Sort { get; set; }

        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Offset { get; set; }

        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Limit { get; set; }
    }
}