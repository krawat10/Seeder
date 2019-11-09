using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public partial class ContentPositions
    {
        [JsonProperty("in-cat-carousel", NullValueHandling = NullValueHandling.Ignore)]
        public long? InCatCarousel { get; set; }

        [JsonProperty("in-cat-carousel-mobile", NullValueHandling = NullValueHandling.Ignore)]
        public long? InCatCarouselMobile { get; set; }

        [JsonProperty("in-cat-carousel-fullwidth", NullValueHandling = NullValueHandling.Ignore)]
        public long? InCatCarouselFullwidth { get; set; }

        [JsonProperty("in-cat-teaser", NullValueHandling = NullValueHandling.Ignore)]
        public long? InCatTeaser { get; set; }

        [JsonProperty("upper-in-cat-teaser", NullValueHandling = NullValueHandling.Ignore)]
        public long? UpperInCatTeaser { get; set; }

        [JsonProperty("entry-point-teasers", NullValueHandling = NullValueHandling.Ignore)]
        public long[] EntryPointTeasers { get; set; }

        [JsonProperty("in-grid-filter", NullValueHandling = NullValueHandling.Ignore)]
        public long? InGridFilter { get; set; }

        [JsonProperty("size-dialog", NullValueHandling = NullValueHandling.Ignore)]
        public long? SizeDialog { get; set; }

        [JsonProperty("search-dialog", NullValueHandling = NullValueHandling.Ignore)]
        public long[] SearchDialog { get; set; }

        [JsonProperty("search-dialog-mobile", NullValueHandling = NullValueHandling.Ignore)]
        public long[] SearchDialogMobile { get; set; }

        [JsonProperty("search-dialog-fullwidth", NullValueHandling = NullValueHandling.Ignore)]
        public long[] SearchDialogFullwidth { get; set; }

        [JsonProperty("sneaker-carousel", NullValueHandling = NullValueHandling.Ignore)]
        public long[] SneakerCarousel { get; set; }

        [JsonProperty("outfits", NullValueHandling = NullValueHandling.Ignore)]
        public long[] Outfits { get; set; }

        [JsonProperty("outfits-mobile", NullValueHandling = NullValueHandling.Ignore)]
        public long[] OutfitsMobile { get; set; }

        [JsonProperty("outfits-fullwidth", NullValueHandling = NullValueHandling.Ignore)]
        public long[] OutfitsFullwidth { get; set; }
    }
}