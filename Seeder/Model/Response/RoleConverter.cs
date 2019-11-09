using System;
using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    internal class RoleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Role) || t == typeof(Role?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "DEFAULT":
                    return Role.Default;
                case "FAMILY":
                    return Role.Family;
                case "HOVER":
                    return Role.Hover;
                case "THUMBNAIL":
                    return Role.Thumbnail;
            }
            throw new Exception("Cannot unmarshal type Role");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Role)untypedValue;
            switch (value)
            {
                case Role.Default:
                    serializer.Serialize(writer, "DEFAULT");
                    return;
                case Role.Family:
                    serializer.Serialize(writer, "FAMILY");
                    return;
                case Role.Hover:
                    serializer.Serialize(writer, "HOVER");
                    return;
                case Role.Thumbnail:
                    serializer.Serialize(writer, "THUMBNAIL");
                    return;
            }
            throw new Exception("Cannot marshal type Role");
        }

        public static readonly RoleConverter Singleton = new RoleConverter();
    }
}