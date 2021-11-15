using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace lega.Pages.Management.Carousels
{
    public class CreateModel : PageModel
    {
        private readonly ICarouselRepasitory _carouselRepasitory;
        public CreateModel(ICarouselRepasitory carouselRepasitory)
        {
            _carouselRepasitory = carouselRepasitory;
            Create = new CreateCarouselModel();
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

                    var result = _carouselRepasitory.Insert(carousel);

                    if (result != null)
                        return RedirectToPage("/Management/Carousels/Index");

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
