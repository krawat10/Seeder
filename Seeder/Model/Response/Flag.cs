using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class Flag
    {
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public Key? Key { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }

        [JsonProperty("tracking_value", NullValueHandling = NullValueHandling.Ignore)]
        public TrackingValue? TrackingValue { get; set; }
    }
}