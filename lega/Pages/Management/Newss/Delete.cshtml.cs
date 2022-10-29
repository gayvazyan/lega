using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;

namespace lega.Pages.Management.Newss
{
    public class DeleteModel : PageModel
    {
        private readonly INewsRepasitory _newsRepasitory;
        private readonly IHostingEnvironment _hostingEnvironment;
        public DeleteModel(INewsRepasitory newsRepasitory, IHostingEnvironment hostingEnvironment)
        {
            _newsRepasitory = newsRepasitory;
            _hostingEnvironment = hostingEnvironment;
            Delete = new DeleteNewsModel();
        }

        public class DeleteNewsModel : News { }

        [BindProperty]
        public DeleteNewsModel Delete { get; set; }

        [BindProperty]
        public string UniqueFileName { get; set; }

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
                UniqueFileName = result.ImageUrl;
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

                    //delete old image from folder 

                    var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "images\\News");
                    var oldFilePath = Path.Combine(folderPath, UniqueFileName);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }

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
