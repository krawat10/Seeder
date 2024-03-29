﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var welcome = CategoryRoot.FromJson(jsonString);

using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShopSeeder.Model.JSON
{
    public partial class CategoryRoot
    {
        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public Category Category { get; set; }
    }

    public class Category
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("id_parent", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? IdParent { get; set; }

        [JsonProperty("level_depth", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? LevelDepth { get; set; }

        [JsonProperty("nb_products_recursive", NullValueHandling = NullValueHandling.Ignore)]
        public long? NbProductsRecursive { get; set; }

        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Active { get; set; }

        [JsonProperty("id_shop_default", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? IdShopDefault { get; set; }

        [JsonProperty("is_root_category", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? IsRootCategory { get; set; }

        [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Position { get; set; }

        [JsonProperty("date_add", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateAdd { get; set; }

        [JsonProperty("date_upd", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateUpd { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("link_rewrite", NullValueHandling = NullValueHandling.Ignore)]
        public string LinkRewrite { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("meta_title", NullValueHandling = NullValueHandling.Ignore)]
        public string MetaTitle { get; set; }

        [JsonProperty("meta_description", NullValueHandling = NullValueHandling.Ignore)]
        public string MetaDescription { get; set; }

        [JsonProperty("meta_keywords", NullValueHandling = NullValueHandling.Ignore)]
        public string MetaKeywords { get; set; }

        [JsonProperty("associations", NullValueHandling = NullValueHandling.Ignore)]
        public Associations Associations { get; set; }
    }

    public class Associations
    {
        [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
        public CategoryElement[] Categories { get; set; }
    }

    public class CategoryElement
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Id { get; set; }
    }

    public partial class CategoryRoot
    {
        public static CategoryRoot FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CategoryRoot>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this CategoryRoot self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
            }
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public static readonly ParseStringConverter Singleton = new ParseStringConverter();

        public override bool CanConvert(Type t)
        {
            return t == typeof(long) || t == typeof(long?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (long.TryParse(value, out l)) return l;
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var value = (long) untypedValue;
            serializer.Serialize(writer, value.ToString());
        }
    }
}