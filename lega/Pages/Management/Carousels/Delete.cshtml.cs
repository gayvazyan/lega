using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace lega.Pages.Management.Carousels
{
    public class DeleteModel : PageModel
    {
        private readonly ICarouselRepasitory _carouselRepasitory;
        public DeleteModel(ICarouselRepasitory carouselRepasitory)
        {
            _carouselRepasitory = carouselRepasitory;
            Delete = new DeleteCarouselModel();
        }

        public class DeleteCarouselModel : Carousel { }

        [BindProperty]
        public DeleteCarouselModel Delete { get; set; }


        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }
        protected void PrepareData(int id)
        {
            var result = _carouselRepasitory.GetByID(id);

            if (result != null)
            {
                Delete.Id = result.Id;
                Delete.Title = result.Title;
                Delete.TitleRu = result.TitleRu;
                Delete.TitleEn = result.TitleEn;
                Delete.Name = result.Name;
                Delete.NameRu = result.NameRu;
                Delete.NameEn = result.NameEn;
                Delete.Context = result.Context;
                Delete.ContextRu = result.ContextRu;
                Delete.ContextEn = result.ContextEn;
                Delete.ImageUrl = result.ImageUrl;
                Delete.State = result.State;
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
                    var carousel = _carouselRepasitory.GetByID(Delete.Id);

                    _carouselRepasitory.Delete(carousel);

                    return RedirectToPage("/Management/Carousels/Index");

                }
                catch (Exception ex)
                {
                    Errors.Add(new ServiceError { Code = "005", Description = ex.Message });
                    PrepareData(Delete.Id);
                }
            }

            return Page();
        }
    }
}
