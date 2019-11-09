using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShopSeeder.Model.Response
{
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                AmountConverter.Singleton,
                KeyConverter.Singleton,
                TrackingValueConverter.Singleton,
                RoleConverter.Singleton,
                BasePriceConverter.Singleton,
                ProductGroupConverter.Singleton,
                KindConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}