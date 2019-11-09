using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class Unit
    {
        [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
        public string Symbol { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        public string Position { get; set; }
    }
}