using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lega.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICarouselRepasitory _carouselRepasitory;

        public IndexModel(ICarouselRepasitory carouselRepasitory)
        {
            _carouselRepasitory = carouselRepasitory;
            CarouselList = new List<Carousel> { };
            CustomerList = new List<Customer> { };
            ServiceList = new List<Service> { };
            About = new About { };
            
        }

        public List<Carousel> CarouselList { get; set; }
        public List<Service> ServiceList { get; set; }
        public List<Customer> CustomerList { get; set; }
        public About About { get; set; }

        public void OnGet()
        {
            #region CarouselList

            // CarouselList = _carouselRepasitory.GetAll().ToList();

            CarouselList.Add(new Carousel
            {
                Id = 1,
                Title = "Lega հաշվապահական գրասենյակ",
                TitleEn = "Lega accounting company",
                Name = "ԿԱԶՄԱԿԵՐՊՈՒԹՅԱՆ ԳՐԱՆՑՈՒՄ",
                NameEn = "REGISTRATION ORGANIZATION",
                Context = "Զբաղվե՛ք բիզնեսով, իսկ հաշվապահությունը վստահեք «Լեգաի» պրոֆեսիոնալ հաշվապահներին։",
                ContextEn = "Do business, and entrust accounting to 'Lega' professional accountants.",
                ImageUrl = "/images/Slider/01.jpg",
                State = "active"
            });

            CarouselList.Add(new Carousel
            {
                Id = 2,
                Title = "Lega հաշվապահական գրասենյակ",
                TitleEn = "Lega accounting company",
                Name = "ՀԱՇՎԱՊԱՀՈՒԹՅԱՆ ՎԱՐՈՒՄ",
                NameEn = "ACCOUNTING",
                Context = "Դիմելով մեզ՝ դուք ստանում եք Հայաստանի լավագույն հաշվապահների գիտելիքներն ու հնարավորությունները ավելի քան մատչելի գներով։",
                ContextEn = "By contacting us, you get the knowledge and opportunities of the best accountants in Armenia at more than affordable prices.",
                ImageUrl = "/images/Slider/02.jpg",
                State = ""
            });

            CarouselList.Add(new Carousel
            {
                Id = 3,
                Title = "Lega հաշվապահական գրասենյակ",
                TitleEn = "Lega accounting company",
                Name = "ՀԱՇՎԵՏՎՈՒԹՅՈՒՆՆԵՐԻ ԿԱԶՄՈՒՄ",
                NameEn = "COMPILATION OF REPORTS",
                Context = "«Լեգա» հաշվապահական գրասենյակի նպատակն է՝ նվազեցնել Ձեր բիզնեսի ֆինանսական ռիսկերն ու բարձրացնել էֆեկտիվությունը։",
                ContextEn = "The goal of 'Lega' accounting office is to reduce the financial risks of your business and increase efficiency.",
                ImageUrl = "/images/Slider/03.jpg",
                State = ""
            });

            #endregion

            #region About
            //Get About
            About = new About
            {
                Id = 1,
                Title = "Հայերեն պատահական տեքստ, հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պա",
                TitleEn = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut et dolore magna aliqua. Ut enim ad minim veniam",
                Name = "Մենք կրեատիվ ենք և հիասքանչ",
                NameEn = "We Are Creative And Awesome",
                Context = "Հայերեն պատահական տեքստ, հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պա Հայերեն պատահական տեքստ, հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պա Հայերեն պատահական տեքստ, հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պա Հայերեն պատահական տեքստ, հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պատահական տեքստ հայերեն պա Հայերեն պատահական տեքստ, հայե։",
                ContextEn = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor.Lorem Ipsum is simply dummy text of the printing and typesetting industry. book.",
                ImageUrl = "/images/Aboutus/01.jpg",
                Visible = true,
            };
            #endregion

            #region Service

            ServiceList.Add(new Service
            {
                Id = 1,
                Title = "UX դիզայն",
                TitleEn = "UX Design",
                Context = "Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին",
                ContextEn = "Backed by some of the biggest names in the industry, Firefox OS is an open platform that fosters greater",
                IconName = "line-chart",
            });

            ServiceList.Add(new Service
            {
                Id = 2,
                Title = "UX դիզայն",
                TitleEn = "UX Design",
                Context = "Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին",
                ContextEn = "Backed by some of the biggest names in the industry, Firefox OS is an open platform that fosters greater",
                IconName = "cubes",
            });

            ServiceList.Add(new Service
            {
                Id = 3,
                Title = "Մարկետինգ",
                TitleEn = "Marketing",
                Context = "Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին",
                ContextEn = "Backed by some of the biggest names in the industry, Firefox OS is an open platform that fosters greater",
                IconName = "pie-chart",
            });

            ServiceList.Add(new Service
            {
                Id = 4,
                Title = "SEO ծառայություններ",
                TitleEn = "SEO Services",
                Context = "Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին",
                ContextEn = "Backed by some of the biggest names in the industry, Firefox OS is an open platform that fosters greater",
                IconName = "bar-chart",
            });

            ServiceList.Add(new Service
            {
                Id = 5,
                Title = "UX դիզայն",
                TitleEn = "UX Design",
                Context = "Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին",
                ContextEn = "Backed by some of the biggest names in the industry, Firefox OS is an open platform that fosters greater",
                IconName = "language",
            });

            ServiceList.Add(new Service
            {
                Id = 6,
                Title = "Մարկետինգ",
                TitleEn = "Marketing",
                Context = "Արդյունաբերության որոշ խոշորագույն անունների աջակցությամբ՝ Firefox OS-ը բաց հարթակ է, որը խթանում է ավելին",
                ContextEn = "Backed by some of the biggest names in the industry, Firefox OS is an open platform that fosters greater",
                IconName = "bullseye",
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



        }
    }
}
