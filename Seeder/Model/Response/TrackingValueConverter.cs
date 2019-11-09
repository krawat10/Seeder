using System;
using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    internal class TrackingValueConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TrackingValue) || t == typeof(TrackingValue?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "discount rate":
                    return TrackingValue.DiscountRate;
                case "mu_sneaker_releases":
                    return TrackingValue.MuSneakerReleases;
                case "new":
                    return TrackingValue.New;
                case "petite":
                    return TrackingValue.Petite;
                case "special offer":
                    return TrackingValue.SpecialOffer;
                case "sustainable":
                    return TrackingValue.Sustainable;
            }
            throw new Exception("Cannot unmarshal type TrackingValue");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TrackingValue)untypedValue;
            switch (value)
            {
                case TrackingValue.DiscountRate:
                    serializer.Serialize(writer, "discount rate");
                    return;
                case TrackingValue.MuSneakerReleases:
                    serializer.Serialize(writer, "mu_sneaker_releases");
                    return;
                case TrackingValue.New:
                    serializer.Serialize(writer, "new");
                    return;
                case TrackingValue.Petite:
                    serializer.Serialize(writer, "petite");
                    return;
                case TrackingValue.SpecialOffer:
                    serializer.Serialize(writer, "special offer");
                    return;
                case TrackingValue.Sustainable:
                    serializer.Serialize(writer, "sustainable");
                    return;
            }
            throw new Exception("Cannot marshal type TrackingValue");
        }

        public static readonly TrackingValueConverter Singleton = new TrackingValueConverter();
    }
}