using System;
using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class Outfit
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("url_key", NullValueHandling = NullValueHandling.Ignore)]
        public string UrlKey { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public CreatorMedia[] Media { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Source { get; set; }

        [JsonProperty("gender", NullValueHandling = NullValueHandling.Ignore)]
        public string Gender { get; set; }

        [JsonProperty("creator", NullValueHandling = NullValueHandling.Ignore)]
        public Creator Creator { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public Item[] Items { get; set; }
    }
}