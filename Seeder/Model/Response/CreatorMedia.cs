using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class CreatorMedia
    {
        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        [JsonProperty("outline_reference", NullValueHandling = NullValueHandling.Ignore)]
        public string OutlineReference { get; set; }
    }
}