using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class ResetFilters
    {
        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public Category[] Categories { get; set; }
    }
}