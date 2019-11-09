using System;
using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    internal class KindConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Kind) || t == typeof(Kind?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "range":
                    return Kind.Range;
                case "single_value":
                    return Kind.SingleValue;
                case "values":
                    return Kind.Values;
            }
            throw new Exception("Cannot unmarshal type Kind");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Kind)untypedValue;
            switch (value)
            {
                case Kind.Range:
                    serializer.Serialize(writer, "range");
                    return;
                case Kind.SingleValue:
                    serializer.Serialize(writer, "single_value");
                    return;
                case Kind.Values:
                    serializer.Serialize(writer, "values");
                    return;
            }
            throw new Exception("Cannot marshal type Kind");
        }

        public static readonly KindConverter Singleton = new KindConverter();
    }
}