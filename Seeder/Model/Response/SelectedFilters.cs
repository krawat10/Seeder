using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class SelectedFilters
    {
        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Categories { get; set; }
    }
}