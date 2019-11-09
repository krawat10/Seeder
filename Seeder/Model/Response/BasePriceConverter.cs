using System;
using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    internal class BasePriceConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BasePrice) || t == typeof(BasePrice?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "4 954,55 zł / 100 g")
            {
                return BasePrice.The495455Zł100G;
            }
            throw new Exception("Cannot unmarshal type BasePrice");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BasePrice)untypedValue;
            if (value == BasePrice.The495455Zł100G)
            {
                serializer.Serialize(writer, "4 954,55 zł / 100 g");
                return;
            }
            throw new Exception("Cannot marshal type BasePrice");
        }

        public static readonly BasePriceConverter Singleton = new BasePriceConverter();
    }
}