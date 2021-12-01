using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lega.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICarouselRepasitory _carouselRepasitory;
        private readonly IAboutRepasitory _aboutRepasitory;
        private readonly IServiceRepasitory _serviceRepasitory;
        private readonly ICustomerRepasitory _customerRepasitory;
        private readonly IPricingRepasitory _pricingRepasitory;
        private readonly IContactRepasitory _contactRepasitory;

        public IndexModel(ICarouselRepasitory carouselRepasitory,
                          IAboutRepasitory aboutRepasitory,
                          IServiceRepasitory serviceRepasitory,
                          ICustomerRepasitory customerRepasitory,
                          IPricingRepasitory pricingRepasitory,
                          IContactRepasitory contactRepasitory)
        {
            _carouselRepasitory = carouselRepasitory;
            _aboutRepasitory = aboutRepasitory;
            _serviceRepasitory = serviceRepasitory;
            _customerRepasitory = customerRepasitory;
            _pricingRepasitory = pricingRepasitory;
            _contactRepasitory = contactRepasitory;

            CarouselList = new List<Carousel> { };
            About = new About { };
            ServiceList = new List<Service> { };
            CustomerList = new List<Customer> { };
            PricingList = new List<Pricing> { };
            Contact = new Contact { };






        }

        public List<Carousel> CarouselList { get; set; }
        public About About { get; set; }
        public List<Service> ServiceList { get; set; }
        public List<Customer> CustomerList { get; set; }
        public List<Pricing> PricingList { get; set; }
        public Contact Contact { get; set; }
     
       

        public void OnGet()
        {
            CarouselList = _carouselRepasitory.GetAll().ToList();

            About = _aboutRepasitory.GetAll().ToList().FirstOrDefault(p=>p.Visible == true);

            ServiceList = _serviceRepasitory.GetAll().ToList();

            CustomerList = _customerRepasitory.GetAll().ToList();

            PricingList = _pricingRepasitory.GetAll().ToList();

            Contact = _contactRepasitory.GetAll().FirstOrDefault(p => p.Visible == true);


            #region News

            #endregion

        }
    }
}
