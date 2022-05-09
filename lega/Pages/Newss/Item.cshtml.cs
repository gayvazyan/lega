using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace lega.Pages.Newss
{
    public class ItemModel : PageModel
    {
        private readonly ICarouselRepasitory _carouselRepasitory;
        private readonly INewsRepasitory _newsRepasitory;

        public ItemModel(ICarouselRepasitory carouselRepasitory, INewsRepasitory newsRepasitory)
        {
            _carouselRepasitory = carouselRepasitory;
            _newsRepasitory = newsRepasitory;

            CarouselList = new List<Carousel> { };
            News = new News { };
        }

        [BindProperty]
        public int LanguageId { get; set; }

        public List<Carousel> CarouselList { get; set; }
        public News News { get; set; }
        public void OnGet(int id, int languageId)
        {
            LanguageId= languageId;
            CarouselList = _carouselRepasitory.GetAll().ToList();
            News = _newsRepasitory.GetAll().FirstOrDefault(p => p.Visible == true && p.Id ==id);
        }
    }
}
