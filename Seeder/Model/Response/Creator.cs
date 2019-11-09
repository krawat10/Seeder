using System;
using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class Creator
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public CreatorMedia[] Media { get; set; }
    }
}