using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lega.Pages.Management.Carousels
{

    public class IndexModel : PageModel
    {
        private readonly ICarouselRepasitory _carouselRepasitory;
        //private readonly IWebHostEnvironment _env;
        public IndexModel(ICarouselRepasitory carouselRepasitory)
                        //IWebHostEnvironment env
     
        {
            _carouselRepasitory = carouselRepasitory;
            //_env = env;
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

            //var resultDir = Path.Combine(_env.WebRootPath, "csv");
            //var resultFileName = "carousel.csv";
            //string resultFilePath = Path.Combine(resultDir, resultFileName);

            //if (System.IO.File.Exists(resultFilePath))
            //{
            //    using (var reader = new StreamReader(@resultFilePath))
            //    {
            //        while (!reader.EndOfStream)
            //        {
            //            var line = reader.ReadLine();
            //            var values = line.Split('|');

            //            var carousel = new Carousel
            //            {
            //                Id = !String.IsNullOrEmpty(values[0]) ? Convert.ToInt32(values[0]) : 0,
            //                Name = values[1],
            //                NameEn = values[2],
            //                Title = values[3],
            //                TitleEn = values[4],
            //                Context = values[5],
            //                ContextEn = values[6],
            //                ImageUrl = values[7],
            //                State = values[8],
            //            };
            //            carouselList.Add(carousel);
            //        }
            //    }
            //}

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
