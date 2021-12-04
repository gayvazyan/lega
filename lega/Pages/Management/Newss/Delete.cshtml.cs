using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace lega.Pages.Management.Newss
{
    public class DeleteModel : PageModel
    {
        private readonly INewsRepasitory _newsRepasitory;
        public DeleteModel(INewsRepasitory newsRepasitory)
        {
            _newsRepasitory = newsRepasitory;
            Delete = new DeleteNewsModel();
        }

        public class DeleteNewsModel : News { }

        [BindProperty]
        public DeleteNewsModel Delete { get; set; }


        private List<ServiceError> _errors;
        public List<ServiceError> Errors
        {
            get => _errors ?? (_errors = new List<ServiceError>());
            set => _errors = value;
        }
        protected void PrepareData(int id)
        {
            var result = _newsRepasitory.GetByID(id);

            if (result != null)
            {
                Delete.Id = result.Id;
                Delete.Title = result.Title;
                Delete.Author = result.Author;
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
                    var news = _newsRepasitory.GetByID(Delete.Id);

                    _newsRepasitory.Delete(news);

                    return RedirectToPage("/Management/Newss/Index");

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
