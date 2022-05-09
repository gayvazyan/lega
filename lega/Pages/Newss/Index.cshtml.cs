using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace lega.Pages.Newss
{
    public class IndexModel : PageModel
    {
        private readonly ICarouselRepasitory _carouselRepasitory;
        private readonly INewsRepasitory _newsRepasitory;

        public IndexModel(ICarouselRepasitory carouselRepasitory,INewsRepasitory newsRepasitory)
        {
            _carouselRepasitory = carouselRepasitory;
            _newsRepasitory = newsRepasitory;

            CarouselList = new List<Carousel> { };
            NewsList = new List<News> { };
        }

        [BindProperty]
        public int LanguageId { get; set; }

        public List<Carousel> CarouselList { get; set; }
        public List<News> NewsList { get; set; }
        public void OnGet(int languageId)
        {
            LanguageId = languageId;
            CarouselList = _carouselRepasitory.GetAll().ToList();
            NewsList = _newsRepasitory.GetAll().OrderByDescending(o=>o.Date).Where(p => p.Visible == true).ToList();
        }
    }
}
