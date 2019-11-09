using System;
using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    internal class ProductGroupConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ProductGroup) || t == typeof(ProductGroup?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "accessoires":
                    return ProductGroup.Accessoires;
                case "beauty":
                    return ProductGroup.Beauty;
                case "clothing":
                    return ProductGroup.Clothing;
                case "shoe":
                    return ProductGroup.Shoe;
            }
            throw new Exception("Cannot unmarshal type ProductGroup");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ProductGroup)untypedValue;
            switch (value)
            {
                case ProductGroup.Accessoires:
                    serializer.Serialize(writer, "accessoires");
                    return;
                case ProductGroup.Beauty:
                    serializer.Serialize(writer, "beauty");
                    return;
                case ProductGroup.Clothing:
                    serializer.Serialize(writer, "clothing");
                    return;
                case ProductGroup.Shoe:
                    serializer.Serialize(writer, "shoe");
                    return;
            }
            throw new Exception("Cannot marshal type ProductGroup");
        }

        public static readonly ProductGroupConverter Singleton = new ProductGroupConverter();
    }
}