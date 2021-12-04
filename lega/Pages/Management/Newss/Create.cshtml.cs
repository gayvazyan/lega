using lega.Core;
using lega.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lega.Pages.Management.Newss
{
    public class CreateModel : PageModel
    {
        private readonly INewsRepasitory _newsRepasitory;
        public CreateModel(INewsRepasitory newsRepasitory)
        {
            _newsRepasitory = newsRepasitory;
            Create = new CreateNewsModel();
        }

        public class CreateNewsModel : News { }

        [BindProperty]
        public CreateNewsModel Create { get; set; }


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
                    var news = new News
                    {
                        Id = Create.Id,
                        Author = Create.Author,
                        AuthorEn = Create.AuthorEn,
                        Title = Create.Title,
                        TitleEn = Create.TitleEn,
                        ShortContext = Create.ShortContext,
                        ShortContextEn = Create.ShortContextEn,
                        Context = Create.Context,
                        ContextEn = Create.ContextEn,
                        Date = Create.Date,
                        ImageUrl = Create.ImageUrl,
                        Visible = Create.Visible,
                    };

                    var result = _newsRepasitory.Insert(news);

                    if (result != null)
                        return RedirectToPage("/Management/Newss/Index");
                   
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
