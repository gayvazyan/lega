using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lega.Pages.Management.Carousels
{
    public class CreateModel : PageModel
    {
        private readonly ICarouselRepasitory _carouselRepasitory;
        private readonly IWebHostEnvironment _env;
        public CreateModel(ICarouselRepasitory carouselRepasitory, IWebHostEnvironment env)
        {
            _carouselRepasitory = carouselRepasitory;
            Create = new CreateCarouselModel();
            _env = env;
        }

        public class CreateCarouselModel : Carousel { }

        [BindProperty]
        public CreateCarouselModel Create { get; set; }


        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var carousel = new Carousel
                    {
                        Id = Create.Id,
                        Name = Create.Name,
                        NameEn = Create.NameEn,
                        Title = Create.Title,
                        TitleEn = Create.TitleEn,
                        Context = Create.Context,
                        ContextEn = Create.ContextEn,
                        ImageUrl = Create.ImageUrl,
                        State = Create.State,
                    };

                    //  var result = _carouselRepasitory.Insert(carousel);

                    //if (result != null)
                    //    return RedirectToPage("/Management/Carousels/Index");


                    if (carousel != null)
                    {
                        try
                        {
                            var resultDir = Path.Combine(_env.WebRootPath, "csv");
                            if (!Directory.Exists(resultDir))
                            {
                                DirectoryInfo di = Directory.CreateDirectory(resultDir);
                            }
                            var resultFileName = "carousel.csv";
                            string resultFilePath = Path.Combine(resultDir, resultFileName);

                            StringBuilder csvCarousel = new StringBuilder();
                            string row = carousel.Id + " | " + carousel.Title + " | " + carousel.TitleEn +
                                        " | " + carousel.Name + " | " + carousel.NameEn + " | " + carousel.Context +
                                        " | " + carousel.ContextEn + " | " + carousel.ImageUrl + " | " + carousel.State;
                            csvCarousel.Append(row);
                            csvCarousel.Append(Environment.NewLine);
                            System.IO.File.AppendAllText(resultFilePath, csvCarousel.ToString());
                            return RedirectToPage("/Management/Carousels/Index");
                        }
                        catch (Exception ex)
                        {

                            Errors.Add(new ServiceError { Code = "004", Description = ex.Message });
                        }
                       
                    }

                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                }
            }
            return Page();
        }
    }
}
