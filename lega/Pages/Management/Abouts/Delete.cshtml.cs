using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace lega.Pages.Management.Abouts
{
    public class DeleteModel : PageModel
    {
        private readonly IAboutRepasitory _aboutRepasitory;
        public DeleteModel(IAboutRepasitory aboutRepasitory)
        {
            _aboutRepasitory = aboutRepasitory;
            Delete = new DeleteAboutModel();
        }

        public class DeleteAboutModel : About { }

        [BindProperty]
        public DeleteAboutModel Delete { get; set; }


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
                Delete.Id = result.Id;
                Delete.Title = result.Title;
                Delete.TitleEn = result.TitleEn;
                Delete.Name = result.Name;
                Delete.NameEn = result.NameEn;
                Delete.Context = result.Context;
                Delete.ContextEn = result.ContextEn;
                Delete.ImageUrl = result.ImageUrl;
                Delete.Visible = result.Visible;
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
                    var about = _aboutRepasitory.GetByID(Delete.Id);

                    _aboutRepasitory.Delete(about);

                    return RedirectToPage("/Management/Abouts/Index");

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
