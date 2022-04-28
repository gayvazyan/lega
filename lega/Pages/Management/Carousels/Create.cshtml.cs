using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace lega.Pages.Management.Carousels
{
    public class CreateModel : PageModel
    {
        private readonly ICarouselRepasitory _carouselRepasitory;
        //private readonly IWebHostEnvironment _env;
        public CreateModel(ICarouselRepasitory carouselRepasitory)
                        // IWebHostEnvironment env)
        {
            _carouselRepasitory = carouselRepasitory;
            Create = new CreateCarouselModel();
            //_env = env;
        }

        public class CreateCarouselModel

        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Վերնագիրը պարտադիր է")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Ռուսերեն վերնագիրը պարտադիր է")]
            public string TitleRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն վերնագիրը պարտադիր է")]
            public string TitleEn { get; set; }

            [Required(ErrorMessage = "Անունը պարտադիր է")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Ռուսերեն անունը պարտադիր է")]
            public string NameRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն անունը պարտադիր է")]
            public string NameEn { get; set; }

            [Required(ErrorMessage = "Տեքստը պարտադիր է")]
            public string Context { get; set; }

            [Required(ErrorMessage = "Ռուսերեն տեքստը պարտադիր է")]
            public string ContextRu { get; set; }

            [Required(ErrorMessage = "Անգլերեն տեքստը պարտադիր է")]
            public string ContextEn { get; set; }

            [Required(ErrorMessage = "Նկարը պարտադիր է")]
            public string ImageUrl { get; set; }
            public string State { get; set; }
        }

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
                        NameRu = Create.NameRu,
                        NameEn = Create.NameEn,
                        Title = Create.Title,
                        TitleRu = Create.TitleRu,
                        TitleEn = Create.TitleEn,
                        Context = Create.Context,
                        ContextRu = Create.ContextRu,
                        ContextEn = Create.ContextEn,
                        ImageUrl = Create.ImageUrl,
                        State = Create.State,
                    };

                    var result = _carouselRepasitory.Insert(carousel);

                    if (result != null)
                        return RedirectToPage("/Management/Carousels/Index");


                    //if (carousel != null)
                    //{
                    //    try
                    //    {
                    //        var resultDir = Path.Combine(_env.WebRootPath, "csv");
                    //        if (!Directory.Exists(resultDir))
                    //        {
                    //            DirectoryInfo di = Directory.CreateDirectory(resultDir);
                    //        }
                    //        var resultFileName = "carousel.csv";
                    //        string resultFilePath = Path.Combine(resultDir, resultFileName);

                    //        StringBuilder csvCarousel = new StringBuilder();
                    //        string row = carousel.Id + " | " + carousel.Title + " | " + carousel.TitleEn +
                    //                    " | " + carousel.Name + " | " + carousel.NameEn + " | " + carousel.Context +
                    //                    " | " + carousel.ContextEn + " | " + carousel.ImageUrl + " | " + carousel.State;
                    //        csvCarousel.Append(row);
                    //        csvCarousel.Append(Environment.NewLine);
                    //        System.IO.File.AppendAllText(resultFilePath, csvCarousel.ToString());
                    //        return RedirectToPage("/Management/Carousels/Index");
                    //    }
                    //    catch (Exception ex)
                    //    {

                    //        Errors.Add(new ServiceError { Code = "004", Description = ex.Message });
                    //    }
                       
                    //}

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
