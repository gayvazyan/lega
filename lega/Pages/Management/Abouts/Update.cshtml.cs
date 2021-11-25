using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

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


        public class UpdateAboutModel : About { }


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
