using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class FamilyArticleMedia
    {
        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        [JsonProperty("packet_shot", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PacketShot { get; set; }
    }
}