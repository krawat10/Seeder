using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class Item
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }
}