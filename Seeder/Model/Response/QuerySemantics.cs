using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class QuerySemantics
    {
        [JsonProperty("positive_filters", NullValueHandling = NullValueHandling.Ignore)]
        public PositiveFilter[] PositiveFilters { get; set; }

        [JsonProperty("negative_filters", NullValueHandling = NullValueHandling.Ignore)]
        public object[] NegativeFilters { get; set; }

        [JsonProperty("reset_query_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ResetQueryUrl { get; set; }

        [JsonProperty("reset_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ResetUrl { get; set; }

        [JsonProperty("app_url", NullValueHandling = NullValueHandling.Ignore)]
        public string AppUrl { get; set; }
    }
}