
using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public class Response
    {
        [JsonProperty("total_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalCount { get; set; }

        [JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
        public Pagination Pagination { get; set; }

        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public string Sort { get; set; }

        [JsonProperty("articles", NullValueHandling = NullValueHandling.Ignore)]
        public Article[] Articles { get; set; }

        [JsonProperty("total_article_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalArticleCount { get; set; }
    }
}