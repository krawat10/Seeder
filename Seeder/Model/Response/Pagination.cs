using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class Pagination
    {
        [JsonProperty("page_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? PageCount { get; set; }

        [JsonProperty("current_page", NullValueHandling = NullValueHandling.Ignore)]
        public long? CurrentPage { get; set; }

        [JsonProperty("per_page", NullValueHandling = NullValueHandling.Ignore)]
        public long? PerPage { get; set; }
    }
}