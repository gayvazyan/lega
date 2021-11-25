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

        public IndexModel(ICarouselRepasitory carouselRepasitory,
                          IAboutRepasitory aboutRepasitory,
                          IServiceRepasitory serviceRepasitory)
        {
            _carouselRepasitory = carouselRepasitory;
            _aboutRepasitory = aboutRepasitory;
            _serviceRepasitory = serviceRepasitory;

            CarouselList = new List<Carousel> { };
            About = new About { };
            ServiceList = new List<Service> { };
            PricingList = new List<Pricing> { };   


            CustomerList = new List<Customer> { };
           
           


        }

        public List<Carousel> CarouselList { get; set; }
        public About About { get; set; }
        public List<Service> ServiceList { get; set; }
        public List<Pricing> PricingList { get; set; }
        public List<Customer> CustomerList { get; set; }
       

        public void OnGet()
        {
            CarouselList = _carouselRepasitory.GetAll().ToList();

            About = _aboutRepasitory.GetAll().ToList().FirstOrDefault(p=>p.Visible == true);

            ServiceList = _serviceRepasitory.GetAll().ToList();

       

            #region Pricing


            PricingList.Add(new Pricing
            {
                Id = 1,
                Name = "ՍՏԱՐՏԱՓ",
                NameEn = "Startup",
                EmployeCount = 1,
                PriceText = "10 մլն",
                PriceTextEn = "10 million",
                Context = "Եթե դեռ չունեք պետական գրանցում, ՍՊԸ գրանցումն ԱՆՎՃԱՐ ",
                ContextEn = "Lorem Ipsum is simply dummy text of the printing and  ",
            }) ;

            PricingList.Add(new Pricing
            {
                Id = 2,
                Name = "ՓՈՔՐ ԲԻԶՆԵՍ",
                NameEn = "Small Bizzzz",
                EmployeCount = 2,
                PriceText = "20 մլն",
                PriceTextEn = "20 million",
                Context = "Խորհրդատվություն, քաղվածքների տրամադրում և այլ աջակցություն աշխ. օրվա ընթացքում ԱՆՍԱՀՄԱՆԱՓԱԿ ",
                ContextEn = "Lorem Ipsum is simply dummy text of the printing and  ",
            });

            PricingList.Add(new Pricing
            {
                Id = 3,
                Name = "ԲԻԶՆԵՍ",
                NameEn = "Bizzzz",
                EmployeCount = 3,
                PriceText = "30 մլն",
                PriceTextEn = "30 million",
                Context = "Խորհրդատվություն, քաղվածքների տրամադրում և այլ աջակցություն աշխ. օրվա ընթացքում ԱՆՍԱՀՄԱՆԱՓԱԿ ",
                ContextEn = "Lorem Ipsum is simply dummy text of the printing and  ",
            });

            PricingList.Add(new Pricing
            {
                Id = 4,
                Name = "ՀԱՏՈՒԿ ԳՈՐԾԸՆԿԵՐ ",
                NameEn = "Spetical partnior",
                EmployeCount = 4,
                PriceText = "40 մլն",
                PriceTextEn = "40 million",
                Context = "Խորհրդատվություն, քաղվածքների տրամադրում և այլ աջակցություն աշխ. օրվա ընթացքում ԱՆՍԱՀՄԱՆԱՓԱԿ ",
                ContextEn = "Lorem Ipsum is simply dummy text of the printing and  ",
            });

            #endregion

            #region Customer


            CustomerList.Add(new Customer
            {
                Id = 1,
                Title = "UX դիզայն",
                TitleEn = "UX Design",
                Context = "Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին ",
                ContextEn = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing. Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system,and expound ",
                ImageURL = "/images/Features/01.jpg",
                LogoURL = "/images/Logo/legaLogo.png",
                OrderNumber = 1,
                TabState = "active"
            });

            CustomerList.Add(new Customer
            {
                Id = 2,
                Title = "Graphic դիզայն",
                TitleEn = "Graphic Design",
                Context = "Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին ",
                ContextEn = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing. Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system,and expound ",
                ImageURL = "/images/Features/02.jpg",
                LogoURL = "/images/Logo/legaLogo.png",
                OrderNumber = 2,
                TabState = ""
            });

            CustomerList.Add(new Customer
            {
                Id = 3,
                Title = "UX դիզայն",
                TitleEn = "UX Design",
                Context = "Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին ",
                ContextEn = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing. Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system,and expound ",
                ImageURL = "/images/Features/03.jpg",
                LogoURL = "/images/Logo/legaLogo.png",
                OrderNumber = 3,
                TabState = ""
            });

            CustomerList.Add(new Customer
            {
                Id = 4,
                Title = "UX դիզայն",
                TitleEn = "UX Design",
                Context = "Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին ",
                ContextEn = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing. Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system,and expound ",
                ImageURL = "/images/Features/04.jpg",
                LogoURL = "/images/Logo/legaLogo.png",
                OrderNumber = 4,
                TabState = ""
            });

            CustomerList.Add(new Customer
            {
                Id = 5,
                Title = "UX դիզայն",
                TitleEn = "UX Design",
                Context = "Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին  Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին ",
                ContextEn = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing. Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system,and expound ",
                ImageURL = "/images/Features/05.jpg",
                LogoURL = "/images/Logo/legaLogo.png",
                OrderNumber = 5,
                TabState = ""
            });

            #endregion

            #region News

            #endregion

        }
    }
}
