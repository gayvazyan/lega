using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lega.Core.Entities
{
    public class Carousel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public string Name { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public string Context { get; set; }
        public string ContextRu { get; set; }
        public string ContextEn { get; set; }
        public string ImageUrl { get; set; }
        public string State { get; set; }
    }
}
