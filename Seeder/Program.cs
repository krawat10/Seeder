using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsvHelper;
using Newtonsoft.Json;
using ShopSeeder.Model.JSON;
using ShopSeeder.Model.Response;
using Category = ShopSeeder.Model.JSON.Category;

namespace ShopSeeder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Executor().Wait();
        }

        private static async Task ApiExecutor()
        {
            var address = "http://104.40.128.65/api/?output_format=JSON";

            var client = GetClient();

            var responseMessage = await client.GetAsync(address);

            var content = await responseMessage.Content.ReadAsStringAsync();
        }

        public static async Task PutCategories()
        {
            var clothes = new Category
            {
                Id = 6,
                Active = 1,
                DateAdd = DateTimeOffset.Now,
                DateUpd = DateTimeOffset.Now,
                Description = "Ubrania dla wszystkich!",
                IdParent = 2,
                IdShopDefault = 1,
                IsRootCategory = 0,
                Associations = new Associations(),
                LevelDepth = 2,
                LinkRewrite = "ubrania",
                MetaDescription = "ubrania opis",
                MetaKeywords = "clothes ubrania bluzy spodnie",
                MetaTitle = "ubrania",
                Name = "Ubrania",
                NbProductsRecursive = -1,
                Position = 0
            };

            var httpClient = GetClient();

            var httpResponseMessage = await httpClient.PostAsync(
                "http://104.40.128.65/api/categories?output_format=JSON",
                new StringContent(JsonConvert.SerializeObject(clothes)));

            var response = await httpResponseMessage.Content.ReadAsStringAsync();
        }

        private static HttpClient GetClient()
        {
            var token = "9Q4VY7X5MR9SAVP2BSSRC76PCZ9AKX9Z";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(
                    Encoding.ASCII.GetBytes(
                        $"{token}:{string.Empty}")));
            return client;
        }

        private static async Task Executor()
        {
            var maxCount = 500;
            var count = 0;
            var client = new HttpClient();

            var articles = new List<Article>();

            while (count < maxCount)
            {
                var response = await client.GetAsync(
                    $"https://www.zalando.pl/api/catalog/articles?categories=kobiety&offset={count}");

                var jsonString = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<Response>(jsonString);

                foreach (var article in model.Articles)
                {
                    article.Gender = "Kobieta";
                }

                articles.AddRange(model.Articles);

                count += 84;
            }

            count = 0;

            while (count < maxCount)
            {
                var response = await client.GetAsync(
                    $"https://www.zalando.pl/api/catalog/articles?categories=mezczyzni&offset={count}");

                var jsonString = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<Response>(jsonString);

                foreach (var article in model.Articles)
                {
                    article.Gender = "Mężczyzna";
                }

                articles.AddRange(model.Articles);

                count += 84;
            }

            var allSizes = articles
                .SelectMany(article => article.Sizes)
                .Distinct()
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Where(s => s.All(char.IsDigit) || s.All(char.IsLetter))
                .OrderBy(s => s)
                .ToList();

            var random = new Random();

            var filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                DateTime.Now.ToString("presta-yyyy-dd-M--HH-mm-ss") + ".csv");

            using (var writer = new StreamWriter(filePath))
            using (var csvWriter = new CsvWriter(writer))

            {
                csvWriter.Configuration.Delimiter = ";";


                csvWriter.WriteField("ID");
                csvWriter.WriteField("Active (0/1)");
                csvWriter.WriteField("Name *");
                csvWriter.WriteField("Categories (x,y,z...)");
                csvWriter.WriteField("Price tax excluded or Price tax included");
                csvWriter.WriteField("Tax rules ID");
                csvWriter.WriteField("Wholesale price");
                csvWriter.WriteField("On sale (0/1)");
                csvWriter.WriteField("Discount amount");
                csvWriter.WriteField("Discount percent");
                csvWriter.WriteField("Discount from (yyyy-mm-dd)");
                csvWriter.WriteField("Discount to (yyyy-mm-dd)");
                csvWriter.WriteField("Reference #");
                csvWriter.WriteField("Supplier reference #");
                csvWriter.WriteField("Supplier");
                csvWriter.WriteField("Manufacturer");
                csvWriter.WriteField("EAN13");
                csvWriter.WriteField("UPC");
                csvWriter.WriteField("Ecotax");
                csvWriter.WriteField("Width");
                csvWriter.WriteField("Height");
                csvWriter.WriteField("Depth");
                csvWriter.WriteField("Weight");
                csvWriter.WriteField("Quantity");
                csvWriter.WriteField("Minimal quantity");
                csvWriter.WriteField("Visibility");
                csvWriter.WriteField("Additional shipping cost");
                csvWriter.WriteField("Unity");
                csvWriter.WriteField("Unit price");
                csvWriter.WriteField("Short description");
                csvWriter.WriteField("Description");
                csvWriter.WriteField("Tags (x,y,z...)");
                csvWriter.WriteField("Meta title");
                csvWriter.WriteField("Meta keywords");
                csvWriter.WriteField("Meta description");
                csvWriter.WriteField("URL rewritten");
                csvWriter.WriteField("Text when in stock");
                csvWriter.WriteField("Text when backorder allowed");
                csvWriter.WriteField("Available for order (0 = No, 1 = Yes)");
                csvWriter.WriteField("Product available date");
                csvWriter.WriteField("Product creation date");
                csvWriter.WriteField("Show price (0 = No, 1 = Yes)");
                csvWriter.WriteField("Image URLs (x,y,z...)");
                csvWriter.WriteField("Delete existing images (0 = No, 1 = Yes)");
                csvWriter.WriteField("Feature(Name:Value:Position)");
                csvWriter.WriteField("Available online only (0 = No, 1 = Yes)");
                csvWriter.WriteField("Condition");
                csvWriter.WriteField("Customizable (0 = No, 1 = Yes)");
                csvWriter.WriteField("Uploadable files (0 = No, 1 = Yes)");
                csvWriter.WriteField("Text fields (0 = No, 1 = Yes)");
                csvWriter.WriteField("Out of stock");
                csvWriter.WriteField("ID / Name of shop");
                csvWriter.WriteField("Advanced stock management");
                csvWriter.WriteField("Depends On Stock");
                csvWriter.WriteField("Warehouse");
                csvWriter.NextRecord();

                var id = 1;
                foreach (var article in articles)

                {
                    WriteArticle(csvWriter, id++, article, random);
                }
            }


            filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                DateTime.Now.ToString("presta-yyyy-dd-M--HH-mm-ss(combine)") + ".csv");

            using (var writer = new StreamWriter(filePath))
            using (var csvWriter = new CsvWriter(writer))
            {
                csvWriter.Configuration.Delimiter = ";";

                csvWriter.WriteField("Product ID*");
                csvWriter.WriteField("Attribute (Name:Type:Position)*");
                csvWriter.WriteField("Value (Value:Position)*");
                csvWriter.WriteField("Quantity");
                csvWriter.WriteField("Minimal quantity");
                csvWriter.NextRecord();

                foreach (var article in articles)
                {
                    var sizePos = 1;
                    if (article.Sizes.Any())
                    {
                        foreach (var articleSize in article.Sizes)
                        {
                            WriteCombination(csvWriter, article, articleSize, sizePos++);
                        }
                    }
                }
            }
        }

        public static Random Random = new Random();

        private static void WriteCombination(CsvWriter csvWriter, Article article, string articleSize, int position)
        {
            csvWriter.WriteField(article.Id);
            csvWriter.WriteField($"Size:select:{position}");
            csvWriter.WriteField($"{articleSize}:{position}");
            csvWriter.WriteField(Random.Next(0,30));
            csvWriter.WriteField(1);
            csvWriter.NextRecord();
        }

        private static void WriteArticle(CsvWriter csvWriter,
            int id,
            Article article,
            Random random)
        {
            article.Id = id;
//                    csvWriter.WriteField("ID");
            csvWriter.WriteField(id++);
            //                    csvWriter.WriteField("Active (0/1)");
            csvWriter.WriteField(1);
            //                    csvWriter.WriteField("Name *");
            csvWriter.WriteField(article.Name);
            //                    csvWriter.WriteField("Categories (x,y,z...)");
            csvWriter.WriteField($"{article.Gender}/{engToPlCategory(article.ProductGroup)}");
            //                    csvWriter.WriteField("Price tax excluded or Price tax included");
            var price = Utils.PriceToDecimal(article.Price.Original) / 100;

            csvWriter.WriteField(price); //todo 100
            //                    csvWriter.WriteField("Tax rules ID");
            csvWriter.WriteField(1);
            //                    csvWriter.WriteField("Wholesale price");
            csvWriter.WriteField(price); //todo 80
            //                    csvWriter.WriteField("On sale (0/1)");
            csvWriter.WriteField(1);
            //                    csvWriter.WriteField("Discount amount");
            csvWriter.WriteField(null);
            //                    csvWriter.WriteField("Discount percent");
            csvWriter.WriteField(null);
            //                    csvWriter.WriteField("Discount from (yyyy-mm-dd)");
            csvWriter.WriteField(null);
            //                    csvWriter.WriteField("Discount to (yyyy-mm-dd)");
            csvWriter.WriteField(null);
            //                    csvWriter.WriteField("Reference #");
            csvWriter.WriteField($"RF-demo_{id}");
            //                    csvWriter.WriteField("Supplier reference #");
            csvWriter.WriteField($"RF-demo_{id}");
            //                    csvWriter.WriteField("Supplier");
            csvWriter.WriteField(article.BrandName);
            //                    csvWriter.WriteField("Manufacturer");
            csvWriter.WriteField(article.BrandName);
            //                    csvWriter.WriteField("EAN13");
            article.ean = Utils.RandomDigits(13);
            csvWriter.WriteField(article.ean);
            //                    csvWriter.WriteField("UPC");
            csvWriter.WriteField(null);
            //                    csvWriter.WriteField("Ecotax");
            csvWriter.WriteField(0);
            //                    csvWriter.WriteField("Width");
            csvWriter.WriteField(Math.Round(random.NextDouble() * 4, 2));
            //                    csvWriter.WriteField("Height");
            csvWriter.WriteField(Math.Round(random.NextDouble() * 4, 2));
            //                    csvWriter.WriteField("Depth");
            csvWriter.WriteField(Math.Round(random.NextDouble() * 4, 2));
            //                    csvWriter.WriteField("Weight");
            csvWriter.WriteField(Math.Round(random.NextDouble() * 4, 2));
            //                    csvWriter.WriteField("Quantity");
            csvWriter.WriteField(random.Next(0, 40));
            //                    csvWriter.WriteField("Minimal quantity");
            csvWriter.WriteField(1);
            //                    csvWriter.WriteField("Visibility");
            csvWriter.WriteField("both");
            //                    csvWriter.WriteField("Additional shipping cost");
            csvWriter.WriteField(random.Next(0, 20));
            //                    csvWriter.WriteField("Unity");
            csvWriter.WriteField(null);
            //                    csvWriter.WriteField("Unit price");
            csvWriter.WriteField(null);
            //                    csvWriter.WriteField("Short description");
            csvWriter.WriteField($"{article.Name},  {article.BrandName}");
            //                    csvWriter.WriteField("Description");
            var sizes = string.Empty;
            if (article.Sizes.Any()) sizes = "Rozmiary: " + article.Sizes.Aggregate((s, s1) => $"{s}, {s1}");

            csvWriter.WriteField($"Nazwa: {article.Name}.  Firma: {article.BrandName}. {sizes}");
            //                    csvWriter.WriteField("Tags (x,y,z...)");
            csvWriter.WriteField(article.UrlKey.Split("-").Take(3).Aggregate((s, s1) => s + "," + s1));
            //                    csvWriter.WriteField("Meta title");
            csvWriter.WriteField($"{article.Name}");
            //                    csvWriter.WriteField("Meta keywords");
            csvWriter.WriteField(article.UrlKey.Split("-").Take(5).Aggregate((s, s1) => s + " " + s1));
            //                    csvWriter.WriteField("Meta description");
            csvWriter.WriteField($"{article.ProductGroup} - {article.Name}");
            //                    csvWriter.WriteField("URL rewritten");
            csvWriter.WriteField(article.UrlKey);
            //                    csvWriter.WriteField("Text when in stock");
            csvWriter.WriteField("W magazynie");
            //                    csvWriter.WriteField("Text when backorder allowed");
            csvWriter.WriteField("Dostepny");
            //                    csvWriter.WriteField("Available for order (0 = No, 1 = Yes)");
            csvWriter.WriteField(1);
            //                    csvWriter.WriteField("Product available date");
            csvWriter.WriteField($"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}");
            //                    csvWriter.WriteField("Product creation date");
            csvWriter.WriteField($"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}");
            //                    csvWriter.WriteField("Show price (0 = No, 1 = Yes)");
            csvWriter.WriteField(1);
            //                    csvWriter.WriteField("Image URLs (x,y,z...)");
            csvWriter.WriteField(
                $"https://mosaic04.ztat.net/vgs/media/catalog-lg/{article.Media.FirstOrDefault()?.Path}");
            //                    csvWriter.WriteField("Delete existing images (0 = No, 1 = Yes)");
            csvWriter.WriteField(1);
            //                    csvWriter.WriteField("Feature(Name:Value:Position)");
            csvWriter.WriteField(null);
            //                    csvWriter.WriteField("Available online only (0 = No, 1 = Yes)");
            csvWriter.WriteField(1);
            //                    csvWriter.WriteField("Condition");
            csvWriter.WriteField("new");
            //                    csvWriter.WriteField("Customizable (0 = No, 1 = Yes)");
            csvWriter.WriteField(0);
            //                    csvWriter.WriteField("Uploadable files (0 = No, 1 = Yes)");
            csvWriter.WriteField(1);
            //                    csvWriter.WriteField("Text fields (0 = No, 1 = Yes)");
            csvWriter.WriteField(0);
            //                    csvWriter.WriteField("Out of stock");
            csvWriter.WriteField(0);
            //                    csvWriter.WriteField("ID / Name of shop");
            csvWriter.WriteField(0);
            //                    csvWriter.WriteField("Advanced stock management");
            csvWriter.WriteField(0);
            //                    csvWriter.WriteField("Depends On Stock");
            csvWriter.WriteField(0);
            //                    csvWriter.WriteField("Warehouse");
            csvWriter.WriteField(0);

            csvWriter.NextRecord();
        }

        private static string engToPlCategory(string enCategory)
        {
            switch (enCategory)
            {
                case "clothing": return "Odzież";
                case "shoe": return "Obuwie";
                case "beauty": return "Kosmetyki";
                case "accessoires": return "Akcesoria";
                case "beach_wear": return "Bikini";
            }

            return "Ubrania";
        }

        public static class ExportData
        {
            public static void ExportCsv<T>(List<T> genericList, string fileName)
            {
                var sb = new StringBuilder();
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var finalPath = Path.Combine(basePath, fileName + ".csv");
                var header = "";
                var info = typeof(T).GetProperties();
                if (!File.Exists(finalPath))
                {
                    var file = File.Create(finalPath);
                    file.Close();
                    foreach (var prop in typeof(T).GetProperties()) header += prop.Name + "; ";

                    header = header.Substring(0, header.Length - 2);
                    sb.AppendLine(header);
                    TextWriter sw = new StreamWriter(finalPath, true);
                    sw.Write(sb.ToString());
                    sw.Close();
                }

                foreach (var obj in genericList)
                {
                    sb = new StringBuilder();
                    var line = "";
                    foreach (var prop in info) line += prop.GetValue(obj, null) + "; ";

                    line = line.Substring(0, line.Length - 2);
                    sb.AppendLine(line);
                    TextWriter sw = new StreamWriter(finalPath, true);
                    sw.Write(sb.ToString());
                    sw.Close();
                }
            }
        }
    }

    internal class Utils
    {
        public static long RandomDigits(int length)
        {
            var random = new Random();
            var s = string.Empty;
            for (var i = 0; i < length; i++) s = string.Concat(s, random.Next(10).ToString());
            return long.Parse(s);
        }

        public static decimal PriceToDecimal(string input)
        {
            return decimal.Parse(Regex.Replace(input, @"[^\d,]", ""));
        }
    }
}