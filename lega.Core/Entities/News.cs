using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lega.Core.Entities
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public string Author { get; set; }
        public string AuthorRu { get; set; }
        public string AuthorEn { get; set; }
        public string ShortContext { get; set; }
        public string ShortContextRu { get; set; }
        public string ShortContextEn { get; set; }
        public string Context { get; set; }
        public string ContextRu { get; set; }
        public string ContextEn { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public bool Visible { get; set; }
        
    }
}
