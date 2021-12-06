using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

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
        private readonly INewsRepasitory _newsRepasitory;

        public IndexModel(ICarouselRepasitory carouselRepasitory,
                          IAboutRepasitory aboutRepasitory,
                          IServiceRepasitory serviceRepasitory,
                          ICustomerRepasitory customerRepasitory,
                          IPricingRepasitory pricingRepasitory,
                          INewsRepasitory newsRepasitory,
                          IContactRepasitory contactRepasitory)
        {
            _carouselRepasitory = carouselRepasitory;
            _aboutRepasitory = aboutRepasitory;
            _serviceRepasitory = serviceRepasitory;
            _customerRepasitory = customerRepasitory;
            _pricingRepasitory = pricingRepasitory;
            _newsRepasitory = newsRepasitory;
            _contactRepasitory = contactRepasitory;

            CarouselList = new List<Carousel> { };
            About = new About { };
            ServiceList = new List<Service> { };
            CustomerList = new List<Customer> { };
            PricingList = new List<Pricing> { };
            NewsList = new List<News> { };
            Contact = new Contact { };
        }

        public List<Carousel> CarouselList { get; set; }
        public About About { get; set; }
        public List<Service> ServiceList { get; set; }
        public List<Customer> CustomerList { get; set; }
        public List<Pricing> PricingList { get; set; }
        public List<News> NewsList { get; set; }
        public Contact Contact { get; set; }
     
       

        public void OnGet()
        {
            CarouselList = _carouselRepasitory.GetAll().ToList();

            About = _aboutRepasitory.GetAll().ToList().FirstOrDefault(p=>p.Visible == true);

            ServiceList = _serviceRepasitory.GetAll().ToList();

            CustomerList = _customerRepasitory.GetAll().ToList();

            PricingList = _pricingRepasitory.GetAll().ToList();

            Contact = _contactRepasitory.GetAll().FirstOrDefault(p => p.Visible == true);
           
            NewsList = _newsRepasitory.GetAll().Where(p => p.Visible == true).Take(3).ToList();
        }
    }
}
