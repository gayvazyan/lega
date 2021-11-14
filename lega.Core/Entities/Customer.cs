using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lega.Core.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string Context { get; set; }
        public string ContextEn { get; set; }
        public string LogoURL { get; set; }
        public string ImageURL { get; set; }
        public int OrderNumber { get; set; }
        public string TabState { get; set; }
    }
}
