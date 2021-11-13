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
        }

        public List<Carousel> CarouselList { get; set; }

        public void OnGet()
        {

            CarouselList = _carouselRepasitory.GetAll().ToList();
        }
    }
}
