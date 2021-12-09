using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lega.Pages.Management.Abouts
{
    public class CreateModel : PageModel
    {
        private readonly IAboutRepasitory _aboutRepasitory;
        public CreateModel(IAboutRepasitory aboutRepasitory)
        {
            _aboutRepasitory = aboutRepasitory;
            Create = new CreateAboutModel();
        }

        public class CreateAboutModel
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
        public CreateAboutModel Create { get; set; }


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
                    var about = new About
                    {
                        Id = Create.Id,
                        Name = Create.Name,
                        NameEn = Create.NameEn,
                        Title = Create.Title,
                        TitleEn = Create.TitleEn,
                        Context = Create.Context,
                        ContextEn = Create.ContextEn,
                        ImageUrl = Create.ImageUrl,
                        Visible = Create.Visible,
                    };

                    var result = _aboutRepasitory.Insert(about);

                    if (result != null)
                        return RedirectToPage("/Management/Abouts/Index");
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
