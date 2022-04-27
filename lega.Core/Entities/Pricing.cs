using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lega.Core.Entities
{
    public class Pricing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public int? EmployeCount { get; set; }
        public string PriceText { get; set; }
        public string PriceTextRu { get; set; }
        public string PriceTextEn { get; set; }
        public string Context { get; set; }
        public string ContextRu { get; set; }
        public string ContextEn { get; set; }

    }
}
