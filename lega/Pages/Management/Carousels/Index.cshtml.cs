using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lega.Pages.Management.Carousels
{

    public class IndexModel : PageModel
    {
        private readonly ICarouselRepasitory _carouselRepasitory;
        public IndexModel(ICarouselRepasitory carouselRepasitory)
        {
            _carouselRepasitory = carouselRepasitory;
            Input = new InputModel();
            InputList = new List<InputModel>();
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public List<InputModel> InputList = new List<InputModel>();
        public class InputModel : Carousel { }

        //START Part Paging
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<Carousel> CarouselList { get; set; }

        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;
        //END Part Paging


        protected void PrepareData()
        {
            var carouselList = _carouselRepasitory.GetAll().ToList();

            if (Input.Title != null)
            {
                carouselList = carouselList.Where(p => p.Title.ToUpper().Contains(Input.Title.ToUpper())).ToList();
            }

            if (Input.Name != null)
            {
                carouselList = carouselList.Where(p => p.Name.ToUpper().Contains(Input.Name.ToUpper())).ToList();
            }


            CarouselList = _carouselRepasitory.GetPaginatedResult(carouselList, CurrentPage, PageSize);


            Count = _carouselRepasitory.GetCount(carouselList);

            InputList = CarouselList.Select(p =>
            {
                return new InputModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    TitleEn = p.TitleEn,
                    Name = p.Name,
                    NameEn = p.NameEn,
                    Context = p.Context,
                    ContextEn = p.ContextEn,
                    ImageUrl = p.ImageUrl,
                    State = p.State,
                };
            }).ToList();
        }
        public void OnGet()
        {
            PrepareData();
        }

        public ActionResult OnPost()
        {
            PrepareData();
            return Page();
        }
    }
}
