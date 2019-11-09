using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSeeder.Model
{
    class Product
    {
        public long ID { get; set; }
        public int Active { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string MetaTitle { get; set; }
        public string KeywordMeta { get; set; }
        public string DescriptionMeta { get; set; }
        public string Url { get; set; }

    }
}
