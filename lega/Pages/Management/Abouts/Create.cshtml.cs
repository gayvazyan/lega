using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

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

        public class CreateAboutModel : About { }

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
