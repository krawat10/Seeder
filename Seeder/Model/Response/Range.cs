using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class Range
    {
        [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
        public double? Min { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public long? Max { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public Unit Unit { get; set; }
    }
}