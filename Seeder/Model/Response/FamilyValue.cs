using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class FamilyValue
    {
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("is_family", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsFamily { get; set; }

        [JsonProperty("family_id", NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyId { get; set; }
    }
}