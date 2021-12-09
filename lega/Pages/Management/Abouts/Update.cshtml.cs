using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lega.Pages.Management.Abouts
{
    public class UpdateModel : PageModel
    {
        private readonly IAboutRepasitory _aboutRepasitory;
        public UpdateModel(IAboutRepasitory aboutRepasitory)
      
        {
            _aboutRepasitory = aboutRepasitory;
            Update = new UpdateAboutModel();
        }


        public class UpdateAboutModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Վերնագիրը պարտադիր է")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Անգլերեն վերնագիրը պարտադիր է")]
            public string TitleEn { get; set; }

            [Required(ErrorMessage = "Անունը պարտադիր է")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Անգլերեն անունը պարտադիր է")]
            public string NameEn { get; set; }

            [Required(ErrorMessage = "Տեքստը պարտադիր է")]
            public string Context { get; set; }

            [Required(ErrorMessage = "Անգլերեն տեքստը պարտադիր է")]
            public string ContextEn { get; set; }

            [Required(ErrorMessage = "Նկարը պարտադիր է")]
            public string ImageUrl { get; set; }
            public bool Visible { get; set; }
        }


        [BindProperty]
        public UpdateAboutModel Update { get; set; }

        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }

        protected void PrepareData(int id)
        {
            var result = _aboutRepasitory.GetByID(id);

            if (result != null)
            {
                Update.Id = result.Id;
                Update.Title = result.Title;
                Update.TitleEn = result.TitleEn;
                Update.Name = result.Name;
                Update.NameEn = result.NameEn;
                Update.Context = result.Context;
                Update.ContextEn = result.ContextEn;
                Update.ImageUrl = result.ImageUrl;
                Update.Visible = result.Visible;
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
                    var about = _aboutRepasitory.GetByID(Update.Id);

                    about.Title = Update.Title;
                    about.TitleEn = Update.TitleEn;
                    about.Name = Update.Name;
                    about.NameEn = Update.NameEn;
                    about.Context = Update.Context;
                    about.ContextEn = Update.ContextEn;
                    about.ImageUrl = Update.ImageUrl;
                    about.Visible = Update.Visible;


                    _aboutRepasitory.Update(about);

                    return RedirectToPage("/Management/Abouts/Index");
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
