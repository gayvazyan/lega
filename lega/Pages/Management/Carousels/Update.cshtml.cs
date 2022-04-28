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
using System.Threading.Tasks;

namespace lega.Pages.Management.Carousels
{
    public class UpdateModel : PageModel
    {
        private readonly ICarouselRepasitory _carouselRepasitory;
        //private readonly IWebHostEnvironment _env;
        public UpdateModel(ICarouselRepasitory carouselRepasitory)
                          // IWebHostEnvironment env
        {
            _carouselRepasitory = carouselRepasitory;
            //_env = env;
            Update = new UpdateCarouselModel();
            //ResultDir = Path.Combine(_env.WebRootPath, "csv");
            //ResultFileName = "carousel.csv";
        }

        [BindProperty]
        public string ResultDir { get; set; }

        [BindProperty]
        public string ResultFileName { get; set; }


        public class UpdateCarouselModel
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
        public UpdateCarouselModel Update { get; set; }

        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }

        protected void PrepareData(int id)
        {

            //string resultFilePath = Path.Combine(ResultDir, ResultFileName);

            //if (System.IO.File.Exists(Path.Combine(ResultDir, ResultFileName)))
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


            //            if (!String.IsNullOrEmpty(values[0]) && Convert.ToInt32(values[0]) == id)
            //            {
            //                Update.Id = Convert.ToInt32(values[0]);
            //                Update.Title = values[1];
            //                Update.TitleEn = values[2];
            //                Update.Name = values[3];
            //                Update.NameEn = values[4];
            //                Update.Context = values[5];
            //                Update.ContextEn = values[6];
            //                Update.ImageUrl = values[7];
            //                Update.State = values[8];
            //            }

            //            CarouselList.Add(carousel);
            //        }
            //    }
            //}
            var result = _carouselRepasitory.GetByID(id);

            if (result != null)
            {
                Update.Id = result.Id;
                Update.Title = result.Title;
                Update.TitleRu = result.TitleRu;
                Update.TitleEn = result.TitleEn;
                Update.Name = result.Name;
                Update.NameRu = result.NameRu;
                Update.NameEn = result.NameEn;
                Update.Context = result.Context;
                Update.ContextRu = result.ContextRu;
                Update.ContextEn = result.ContextEn;
                Update.ImageUrl = result.ImageUrl;
                Update.State = result.State;
            }
        }
        public void OnGet(int id)
        {
            PrepareData(id);
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var carousel = _carouselRepasitory.GetByID(Update.Id);

                    carousel.Title = Update.Title;
                    carousel.TitleRu = Update.TitleRu;
                    carousel.TitleEn = Update.TitleEn;
                    carousel.Name = Update.Name;
                    carousel.NameRu = Update.NameRu;
                    carousel.NameEn = Update.NameEn;
                    carousel.Context = Update.Context;
                    carousel.ContextRu = Update.ContextRu;
                    carousel.ContextEn = Update.ContextEn;
                    carousel.ImageUrl = Update.ImageUrl;
                    carousel.State = Update.State;


                  _carouselRepasitory.Update(carousel);

                    return RedirectToPage("/Management/Carousels/Index");


                    //if (!Directory.Exists(ResultDir))
                    //{
                    //    DirectoryInfo di = Directory.CreateDirectory(ResultDir);
                    //}
                    //string resultFilePath = Path.Combine(ResultDir, ResultFileName);

                    //Delete List to carousel.csv  File


                    //if (System.IO.File.Exists(resultFilePath))
                    //{
                    //    System.IO.File.Delete(resultFilePath);
                    //}

                    //Write List to carousel.csv  File

                    //foreach (var carousel in CarouselList)
                    //{
                    //    StringBuilder csvCarousel = new StringBuilder();

                    //    if (carousel.Id == Update.Id)
                    //    {
                    //        carousel.Title = Update.Title;
                    //        carousel.TitleEn = Update.TitleEn;
                    //        carousel.Name = Update.Name;
                    //        carousel.NameEn = Update.NameEn;
                    //        carousel.Context = Update.Context;
                    //        carousel.ContextEn = Update.ContextEn;
                    //        carousel.ContextEn = Update.ContextEn;
                    //        carousel.ImageUrl = Update.ImageUrl;
                    //        carousel.State = Update.State;
                    //    }

                    //    string row = carousel.Id + " , " + carousel.Title + " , " + carousel.TitleEn +
                    //           " , " + carousel.Name + " , " + carousel.NameEn + " , " + carousel.Context +
                    //           " , " + carousel.ContextEn + " , " + carousel.ImageUrl + " , " + carousel.State;
                    //    csvCarousel.Append(row);
                    //    csvCarousel.Append(Environment.NewLine);
                    //    System.IO.File.AppendAllText(resultFilePath, csvCarousel.ToString());
                    //}

                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                    PrepareData(Update.Id);
                }
            }
            else
            {
                PrepareData(Update.Id);
            }

            return Page();
        }
    }
}
