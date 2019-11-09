using System;
using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    internal class KeyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Key) || t == typeof(Key?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "assortmentArea":
                    return Key.AssortmentArea;
                case "campaign":
                    return Key.Campaign;
                case "csr":
                    return Key.Csr;
                case "discountRate":
                    return Key.DiscountRate;
                case "new":
                    return Key.New;
                case "specialOffer":
                    return Key.SpecialOffer;
            }
            throw new Exception("Cannot unmarshal type Key");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Key)untypedValue;
            switch (value)
            {
                case Key.AssortmentArea:
                    serializer.Serialize(writer, "assortmentArea");
                    return;
                case Key.Campaign:
                    serializer.Serialize(writer, "campaign");
                    return;
                case Key.Csr:
                    serializer.Serialize(writer, "csr");
                    return;
                case Key.DiscountRate:
                    serializer.Serialize(writer, "discountRate");
                    return;
                case Key.New:
                    serializer.Serialize(writer, "new");
                    return;
                case Key.SpecialOffer:
                    serializer.Serialize(writer, "specialOffer");
                    return;
            }
            throw new Exception("Cannot marshal type Key");
        }

        public static readonly KeyConverter Singleton = new KeyConverter();
    }
}