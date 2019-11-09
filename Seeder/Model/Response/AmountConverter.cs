using System;
using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    internal class AmountConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Amount) || t == typeof(Amount?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "2,2 g")
            {
                return Amount.The22G;
            }
            throw new Exception("Cannot unmarshal type Amount");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Amount)untypedValue;
            if (value == Amount.The22G)
            {
                serializer.Serialize(writer, "2,2 g");
                return;
            }
            throw new Exception("Cannot marshal type Amount");
        }

        public static readonly AmountConverter Singleton = new AmountConverter();
    }
}