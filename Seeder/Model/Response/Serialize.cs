using Newtonsoft.Json;

namespace ShopSeeder.Model.Response
{
    public static class Serialize
    {
        public static string ToJson(this Response self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}