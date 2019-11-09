using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class ToggleGroupDatum
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("groupKeys", NullValueHandling = NullValueHandling.Ignore)]
        public string[] GroupKeys { get; set; }
    }
}