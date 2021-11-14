using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lega.Core.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string Context { get; set; }
        public string ContextEn { get; set; }
        public string IconName { get; set; }
    }
}
