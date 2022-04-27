using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lega.Core.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleRu { get; set; }
        public string TitleEn { get; set; }
        public string Address { get; set; }
        public string AddressRu { get; set; }
        public string AddressEn { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public bool Visible { get; set; }

    }
}
